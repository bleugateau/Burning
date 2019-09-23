using Burning.DofusProtocol.Datacenter;
using FlatyBot.Common.Extensions;
using FlatyBot.Common.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Burning.DofusProtocol.Data.D2o
{
    public class D2oReader
    {
        private const int NullIdentifier = unchecked((int) 0xAAAAAAAA);

        /// <summary>
        ///     Contains all assembly where the reader search D2o class
        /// </summary>
        public static List<Assembly> ClassesContainers = new List<Assembly>
        {
            typeof(Breed).Assembly
        };

        private static readonly Dictionary<Type, Func<object[], object>> ObjectCreators =
            new Dictionary<Type, Func<object[], object>>();

        private readonly IDataReader _reader;


        private int _classcount;
        private int _headeroffset;
        private int _indextablelen;

        /// <summary>
        ///     Create and initialise a new D2o file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        public D2oReader(string filePath)
            : this(new FastBigEndianReader(File.ReadAllBytes(filePath)))
        {
            FilePath = filePath;
        }

        public D2oReader(Stream stream)
        {
            _reader = new BigEndianReader(stream);
            Initialize();
        }

        public D2oReader(IDataReader reader)
        {
            _reader = reader;
            Initialize();
        }

        public string FilePath { get; }

        public string FileName => Path.GetFileNameWithoutExtension(FilePath);

        public int IndexCount => Indexes.Count;

        public Dictionary<int, D2oClassDefinition> Classes { get; private set; }

        public Dictionary<int, int> Indexes { get; private set; } = new Dictionary<int, int>();

        private void Initialize()
        {
            IDataReader obj = this._reader;
            lock (obj)
            {
                var header = obj.ReadUTFBytes(3);

                if (header != "D2O")
                    throw new Exception("Header doesn't equal the string \'D2O\' : Corrupted file");

                ReadIndexTable();
                ReadClassesTable();
            }
        }
        private void ReadIndexTable()
        {
            this._headeroffset = this._reader.ReadInt();
            this._reader.Seek(this._headeroffset, SeekOrigin.Begin);
            this._indextablelen = this._reader.ReadInt();
            this.Indexes = new Dictionary<int, int>(this._indextablelen / 8);
            for (int i = 0; i < this._indextablelen; i += 8)
            {
                this.Indexes.Add(this._reader.ReadInt(), this._reader.ReadInt());
            }
        }

        private void ReadClassesTable()
        {
            this._classcount = _reader.ReadInt();
            this.Classes = new Dictionary<int, D2oClassDefinition>(this._classcount);
            for (int i = 0; i < this._classcount; i++)
            {
                int num = this._reader.ReadInt();
                string text = this._reader.ReadUTF();
                string packagename = this._reader.ReadUTF();
                Type type = D2oReader.FindType(text);
                if (type == null)
                {
                    type = D2oReader.FindType(text + "s");
                    if (type == null)
                    {
                        throw new ArgumentException(text);
                    }
                }
                int num2 = this._reader.ReadInt();
                List<D2oFieldDefinition> list = new List<D2oFieldDefinition>(num2);
                for (int j = 0; j < num2; j++)
                {
                    string text2 = this._reader.ReadUTF().Replace("_", "");
                    text2 = char.ToUpper(text2[0]).ToString() + text2.Substring(1);
                    D2oFieldType d2oFieldType = (D2oFieldType)this._reader.ReadInt();
                    List<Tuple<D2oFieldType, string>> list2 = new List<Tuple<D2oFieldType, string>>();
                    if (d2oFieldType == D2oFieldType.List)
                    {
                        D2oFieldType d2oFieldType2;
                        do
                        {
                            string item = this._reader.ReadUTF();
                            d2oFieldType2 = (D2oFieldType)this._reader.ReadInt();
                            list2.Add(Tuple.Create<D2oFieldType, string>(d2oFieldType2, item));
                        }
                        while (d2oFieldType2 == D2oFieldType.List);
                    }
                    FieldInfo field = type.GetField(text2);
                    if (field == null)
                    {
                        field = type.GetField(char.ToLower(text2[0]).ToString() + text2.Substring(1));
                        if (field == null)
                        {
                            throw new Exception(string.Format("Missing field '{0}' ({1}) in class '{2}'", text2, d2oFieldType, type.Name));
                        }
                    }
                    list.Add(new D2oFieldDefinition(text2, d2oFieldType, field, this._reader.Position, list2.ToArray()));
                }
                this.Classes.Add(num, new D2oClassDefinition(num, text, packagename, type, list, this._reader.Position));
            }
        }

        private static Type FindType(string className)
        {
            IEnumerable<Type> source = from asm in D2oReader.ClassesContainers
                                       let types = asm.GetTypes()
                                       from type in types
                                       where type.Name.Equals(className, StringComparison.InvariantCulture) && type.HasInterface(typeof(IDataObject))
                                       select type;
            Type result;
            try
            {
                result = source.Single<Type>();
            }
            catch
            {
                result = null;
            }
            return result;
        }

        private bool IsTypeDefined(Type type)
        {
            return Classes.Count(entry => entry.Value.ClassType == type) > 0;
        }

        /// <summary>
        ///     Get all objects that corresponding to T associated to his index
        /// </summary>
        /// <typeparam name="T">Corresponding class</typeparam>
        /// <param name="allownulled">True to adding null instead of throwing an exception</param>
        /// <returns></returns>
        public Dictionary<int, T> ReadObjects<T>(bool allownulled = false)
            where T : class
        {
            if (!IsTypeDefined(typeof(T)))
                throw new Exception("The file doesn't contain this class");

            var result = new Dictionary<int, T>(Indexes.Count);

            using (var reader = CloneReader())
            {
                foreach (var index in Indexes)
                {
                    reader.Seek(index.Value, SeekOrigin.Begin);

                    var classid = reader.ReadInt();

                    if (Classes[classid].ClassType != typeof(T) &&
                        !Classes[classid].ClassType.IsSubclassOf(typeof(T))) continue;
                    try
                    {
                        result.Add(index.Key, BuildObject(Classes[classid], reader) as T);
                    }
                    catch
                    {
                        if (allownulled)
                            result.Add(index.Key, default(T));
                        else
                            throw;
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     Get all objects associated to his index
        /// </summary>
        /// <param name="allownulled">True to adding null instead of throwing an exception</param>
        /// <returns></returns>
        public Dictionary<int, object> ReadObjects(bool allownulled = false, bool cloneReader = false)
        {
            var result = new Dictionary<int, object>(Indexes.Count);

            var reader = cloneReader ? CloneReader() : _reader;

            foreach (var index in Indexes)
            {
                reader.Seek(index.Value, SeekOrigin.Begin);

                try
                {
                    result.Add(index.Key, ReadObject(index.Key, reader));
                }
                catch
                {
                    if (allownulled)
                        result.Add(index.Key, null);
                    else
                        throw;
                }
            }

            if (cloneReader)
                reader.Dispose();

            return result;
        }

        /// <summary>
        ///     Get an object from his index
        /// </summary>
        /// <param name="cloneReader">When sets to true it copies the reader to have a thread safe method</param>
        /// <returns></returns>
        public object ReadObject(int index, bool cloneReader = false)
        {
            if (cloneReader)
                using (var reader = CloneReader())
                {
                    return ReadObject(index, reader);
                }

            lock (_reader)
            {
                return ReadObject(index, _reader);
            }
        }

        private object ReadObject(int index, IDataReader reader)
        {
            var offset = Indexes[index];
            reader.Seek(offset, SeekOrigin.Begin);

            var classid = reader.ReadInt();

            var result = BuildObject(Classes[classid], reader);

            return result;
        }

        private object BuildObject(D2oClassDefinition classDefinition, IDataReader reader)
        {
            if (!ObjectCreators.ContainsKey(classDefinition.ClassType))
            {
                var creator = CreateObjectBuilder(classDefinition.ClassType,
                    classDefinition.Fields.Select(
                        entry => entry.Value.FieldInfo).ToArray());

                ObjectCreators.Add(classDefinition.ClassType, creator);
            }

            var values = new List<object>();
            foreach (var field in classDefinition.Fields.Values)
            {
                var fieldValue = ReadField(reader, field, field.TypeId);

                if (field.FieldType.IsInstanceOfType(fieldValue))
                    values.Add(fieldValue);
                else if (fieldValue is IConvertible &&
                         field.FieldType.GetInterface("IConvertible") != null)
                    try
                    {
                        if (fieldValue is int && (int) fieldValue < 0 && field.FieldType == typeof(uint))
                            values.Add(unchecked ((uint) (int) fieldValue));
                        else
                            values.Add(Convert.ChangeType(fieldValue, field.FieldType));
                    }
                    catch
                    {
                        throw new Exception(
                            $"Field '{classDefinition.Name}.{field.Name}' with value {fieldValue} is not of type '{fieldValue.GetType()}'");
                    }
                else
                    throw new Exception(
                        $"Field '{classDefinition.Name}.{field.Name}' with value {fieldValue} is not of type '{fieldValue.GetType()}'");
            }

            return ObjectCreators[classDefinition.ClassType](values.ToArray());
        }

        public T ReadObject<T>(int index, bool cloneReader = false, bool noExceptionThrown = false)
            where T : class
        {
            if (cloneReader)
                using (var reader = CloneReader())
                {
                    return ReadObject<T>(index, reader, noExceptionThrown);
                }

            return ReadObject<T>(index, _reader, noExceptionThrown);
        }

        public Type ReadObject(Type T, int index, bool cloneReader = false, bool noEx = false)
        {
            if(cloneReader)
                using (var reader = CloneReader())
                    return ReadObject(T, index, reader, noEx);
            return ReadObject(T, index, _reader, noEx);
        }



        private T ReadObject<T>(int index, IDataReader reader, bool noExceptionThrown = false)
            where T : class
        {
            if (!IsTypeDefined(typeof(T)))
                throw new Exception("The file doesn't contain this class"); // Serious error, exception always thrown

            if (!Indexes.TryGetValue(index, out var offset))
            {
                if (noExceptionThrown) return null;
                throw new Exception($"Can't find Index {index} in {FileName}");
            }

            reader.Seek(offset, SeekOrigin.Begin);

            var classid = reader.ReadInt();

            if (Classes[classid].ClassType != typeof(T) && !Classes[classid].ClassType.IsSubclassOf(typeof(T)))
                throw new Exception(string.Format("Wrong type, try to read object with {1} instead of {0}",
                    typeof(T).Name, Classes[classid].ClassType.Name));

            return BuildObject(Classes[classid], reader) as T;
        }

        private Type ReadObject(Type T, int index, IDataReader reader, bool noEx = false)
        {
            if (!IsTypeDefined(T))
                throw new Exception("The file doesn't contain this class");
            if (!Indexes.TryGetValue(index, out var offset))
            {
                if (noEx) return null;
                throw new Exception($"Can't find Index {index} in {FileName}");
            }
            reader.Seek(offset, SeekOrigin.Begin);
            var classid = reader.ReadInt();
            if(Classes[classid].ClassType != T && !Classes[classid].ClassType.IsSubclassOf(T))
                throw new Exception(string.Format("Wrong type, try to read object with {1} instead of {0}",
                    T.Name, Classes[classid].ClassType.Name));
            return BuildObject(Classes[classid], reader).GetType();
        }

        public Dictionary<int, D2oClassDefinition> GetObjectsClasses()
        {
            return Indexes.ToDictionary(index => index.Key, index => GetObjectClass(index.Key));
        }


        /// <summary>
        ///     Get the class corresponding to the object at the given index
        /// </summary>
        public D2oClassDefinition GetObjectClass(int index)
        {
            lock (_reader)
            {
                var offset = Indexes[index];
                _reader.Seek(offset, SeekOrigin.Begin);

                var classid = _reader.ReadInt();

                return Classes[classid];
            }
        }

        private object ReadField(IDataReader reader, D2oFieldDefinition field, D2oFieldType typeId,
            int vectorDimension = 0)
        {
            switch (typeId)
            {
                case D2oFieldType.Int:
                    return ReadFieldInt(reader);
                case D2oFieldType.Bool:
                    return ReadFieldBool(reader);
                case D2oFieldType.String:
                    return ReadFieldUtf(reader);
                case D2oFieldType.Double:
                    return ReadFieldDouble(reader);
                case D2oFieldType.I18N:
                    return ReadFieldI18N(reader);
                case D2oFieldType.UInt:
                    return ReadFieldUInt(reader);
                case D2oFieldType.List:
                    return ReadFieldVector(reader, field, vectorDimension);
                default:
                    return ReadFieldObject(reader);
            }
        }


        private object ReadFieldVector(IDataReader reader, D2oFieldDefinition field, int vectorDimension)
        {
            var count = reader.ReadInt();

            var vectorType = field.FieldType;
            for (var i = 0; i < vectorDimension; i++)
                vectorType = vectorType.GetGenericArguments()[0];

            lock (ObjectCreators
            ) // We sometimes have error on objectCreators.Add(vectorType, creator) : mainlock allready in the dictionary
            {
                if (!ObjectCreators.ContainsKey(vectorType))
                {
                    var creator = CreateObjectBuilder(vectorType);

                    ObjectCreators.Add(vectorType, creator);
                }
            }

            var result = ObjectCreators[vectorType](new object[0]) as IList;

            for (var i = 0; i < count; i++)
            {
                vectorDimension++;
                try
                {
                    var obj = ReadField(reader, field, field.VectorTypes[vectorDimension - 1].Item1, vectorDimension);
                    result.Add(obj);
                }
                catch
                {
                }
                vectorDimension--;
            }

            return result;
        }

        private object ReadFieldObject(IDataReader reader)
        {
            var classid = reader.ReadInt();

            return classid == NullIdentifier
                ? null
                : (Classes.Keys.Contains(classid) ? BuildObject(Classes[classid], reader) : null);
        }

        private static int ReadFieldInt(IDataReader reader)
        {
            return reader.ReadInt();
        }

        private static uint ReadFieldUInt(IDataReader reader)
        {
            return reader.ReadUInt();
        }

        private static bool ReadFieldBool(IDataReader reader)
        {
            return reader.ReadByte() != 0;
        }

        private static string ReadFieldUtf(IDataReader reader)
        {
            return reader.ReadUTF();
        }

        private static double ReadFieldDouble(IDataReader reader)
        {
            return reader.ReadDouble();
        }

        private static int ReadFieldI18N(IDataReader reader)
        {
            return reader.ReadInt();
        }

        internal IDataReader CloneReader()
        {
            lock (_reader)
            {
                if (_reader.Position > 0)
                    _reader.Seek(0, SeekOrigin.Begin);

                if (_reader is FastBigEndianReader)
                    return new FastBigEndianReader(((FastBigEndianReader) _reader).Buffer);
                Stream streamClone = new MemoryStream();
                ((BigEndianReader) _reader).BaseStream.CopyTo(streamClone);

                return new BigEndianReader(streamClone);
            }
        }

        public void Close()
        {
            lock (_reader)
            {
                _reader.Dispose();
            }
        }

        private static Func<object[], object> CreateObjectBuilder(Type classType, params FieldInfo[] fields)
        {
            var method = new DynamicMethod(Guid.NewGuid().ToString("N"), typeof(object),
                new[] {typeof(object[])}.ToArray());

            var ilGenerator = method.GetILGenerator();

            ilGenerator.DeclareLocal(classType);
            ilGenerator.DeclareLocal(classType);

            ilGenerator.Emit(OpCodes.Newobj, classType.GetConstructor(Type.EmptyTypes));
            ilGenerator.Emit(OpCodes.Stloc_0);
            for (var i = 0; i < fields.Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldloc_0);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);

                ilGenerator.Emit(fields[i].FieldType.IsClass ? OpCodes.Castclass : OpCodes.Unbox_Any,
                    fields[i].FieldType);

                ilGenerator.Emit(OpCodes.Stfld, fields[i]);
            }

            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Stloc_1);
            ilGenerator.Emit(OpCodes.Ldloc_1);
            ilGenerator.Emit(OpCodes.Ret);

            return
                (Func<object[], object>)
                method.CreateDelegate(Expression.GetFuncType(new[] {typeof(object[]), typeof(object)}.ToArray()));
        }
    }
}
