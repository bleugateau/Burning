using System;
using System.Reflection;

namespace Burning.DofusProtocol.Data.D2o
{
    public class D2oFieldDefinition
    {
        public D2oFieldDefinition(string name, D2oFieldType typeId, FieldInfo fieldInfo, long offset,
            params Tuple<D2oFieldType, string>[] vectorsTypes)
        {
            Name = name;
            TypeId = typeId;
            FieldInfo = fieldInfo;
            Offset = offset;

            VectorTypes = vectorsTypes;
        }

        public D2oFieldDefinition(string name, D2oFieldType typeId, PropertyInfo propertyInfo, long offset,
            params Tuple<D2oFieldType, string>[] vectorsTypes)
        {
            Name = name;
            TypeId = typeId;
            PropertyInfo = propertyInfo;
            Offset = offset;

            VectorTypes = vectorsTypes;
        }

        public string Name { get; set; }

        public D2oFieldType TypeId { get; set; }

        public Tuple<D2oFieldType, string>[] VectorTypes { get; set; }

        internal long Offset { get; set; }

        public Type FieldType => PropertyInfo != null ? PropertyInfo.PropertyType : FieldInfo.FieldType;

        internal PropertyInfo PropertyInfo { get; set; }

        internal FieldInfo FieldInfo { get; set; }

        public object GetValue(object instance)
        {
            if (PropertyInfo != null)
                return PropertyInfo.GetValue(instance, null);
            if (FieldInfo != null)
                return FieldInfo.GetValue(instance);
            throw new NullReferenceException();
        }

        public void SetValue(object instance, object value)
        {
            if (PropertyInfo != null)
                PropertyInfo.SetValue(instance, value, null);
            else if (FieldInfo != null)
                FieldInfo.SetValue(instance, value);
        }
    }
}
