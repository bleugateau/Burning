using Burning.Common.Extensions;
using FlatyBot.Common.IO;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Common.Utility.EntityLook
{
    public class Look
    {
        #region Vars
        private Dictionary<int, int> _colors = new Dictionary<int, int>();
        private List<int> _scales = new List<int>();
        private List<uint> _skins = new List<uint>();
        private List<SubLook> _subLooks = new List<SubLook>();
        private uint _bonesID;
        private SubEntityBindingPointCategoryEnum _binding;
        #endregion

        #region Properties
        public List<SubLook> SubLooks
        {
            get
            {
                return this._subLooks;
            }
        }
        public uint BonesID
        {
            get
            {
                return this._bonesID;
            }
            set
            {
                this._bonesID = value;
            }
        }
        public List<uint> Skins
        {
            get
            {
                return this._skins;
            }
        }
        public List<int> Scales
        {
            get
            {
                return this._scales;
            }
        }
        public Dictionary<int, int> Colors
        {
            get
            {
                return this._colors;
            }
        }
        public SubEntityBindingPointCategoryEnum Binging
        {
            get
            {
                return _binding;
            }
        }
        #endregion

        #region Constructors / Parsers
        public Look()
        { }
        public Look(byte[] datas)
        {
            _colors = new Dictionary<int, int>();
            _scales = new List<int>();
            _skins = new List<uint>();
            _subLooks = new List<SubLook>();

            var reader = new BigEndianReader(datas);
            int count = 0;

            count = reader.ReadShort();
            for (int i = 0; i < count; i++)
            {
                _colors.Add(reader.ReadInt(), reader.ReadInt());
            }
            count = reader.ReadShort();
            for (int i = 0; i < count; i++)
            {
                var test = reader.ReadInt();
                _scales.Add(test);
            }
            count = reader.ReadShort();
            for (int i = 0; i < count; i++)
            {
                _skins.Add(reader.ReadUInt());
            }
            count = reader.ReadShort();
            for (int i = 0; i < count; i++)
            {

            }

            _bonesID = (uint)reader.ReadUInt();
            _binding = (SubEntityBindingPointCategoryEnum)reader.ReadUInt();
        }
        public Look(uint bones, uint[] skins, Dictionary<int, int> indexedColors, int[] scales, SubLook[] subLooks)
        {
            this._bonesID = bones;
            this._skins = skins.ToList<uint>();
            this._colors = indexedColors;
            this._scales = scales.ToList<int>();
            this._subLooks = subLooks.ToList<SubLook>();
        }

        public static Look Parse(string str)
        {
            if (string.IsNullOrEmpty(str) || str[0] != '{')
            {
                Console.WriteLine("Incorrect EntityLook format : {0}", str);
                return new Look();
            }
            int i = 1;
            int num = str.IndexOf('|');
            if (num == -1)
            {
                num = str.IndexOf("}");
                if (num == -1)
                {
                    throw new System.Exception("Incorrect EntityLook format : " + str);
                }
            }
            uint bones = uint.Parse(str.Substring(i, num - i));
            i = num + 1;
            uint[] skins = new uint[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                skins = Look.ParseCollection<uint>(str.Substring(i, num - i), new Func<string, uint>(uint.Parse));
                i = num + 1;
            }
            Tuple<int, int>[] source = new Tuple<int, int>[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                source = Look.ParseCollection<Tuple<int, int>>(str.Substring(i, num - i), new Func<string, Tuple<int, int>>(Look.ParseIndexedColor));
                i = num + 1;
            }
            int[] scales = new int[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                scales = Look.ParseCollection<int>(str.Substring(i, num - i), new Func<string, int>(int.Parse));
                i = num + 1;
            }
            List<SubLook> list = new List<SubLook>();
            while (i < str.Length)
            {
                int num2 = str.IndexOf('@', i, 3);
                int num3 = str.IndexOf('=', num2 + 1, 3);
                byte category = byte.Parse(str.Substring(i, num2 - i));
                byte b = byte.Parse(str.Substring(num2 + 1, num3 - (num2 + 1)));
                int num4 = 0;
                int num5 = num3 + 1;
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                do
                {
                    stringBuilder.Append(str[num5]);
                    if (str[num5] == '{')
                    {
                        num4++;
                    }
                    else
                    {
                        if (str[num5] == '}')
                        {
                            num4--;
                        }
                    }
                    num5++;
                }
                while (num4 > 0);
                list.Add(new SubLook((sbyte)b, (SubEntityBindingPointCategoryEnum)category, Look.Parse(stringBuilder.ToString())));
                i = num5 + 1;
            }
            return new Look(bones, skins, source.ToDictionary((Tuple<int, int> x) => x.Item1, (Tuple<int, int> x) => x.Item2), scales, list.ToArray());
        }
        private static Tuple<int, int> ParseIndexedColor(string str)
        {
            int num = str.IndexOf("=");
            bool flag = str[num + 1] == '#';
            int item = int.Parse(str.Substring(0, num));
            int item2 = int.Parse(str.Substring(num + (flag ? 2 : 1), str.Length - (num + (flag ? 2 : 1))), flag ? System.Globalization.NumberStyles.HexNumber : System.Globalization.NumberStyles.Integer);
            return Tuple.Create<int, int>(item, item2);
        }
        private static T[] ParseCollection<T>(string str, Func<string, T> converter)
        {
            T[] result;
            if (string.IsNullOrEmpty(str))
            {
                result = new T[0];
            }
            else
            {
                int num = 0;
                int num2 = str.IndexOf(',', 0);
                if (num2 == -1)
                {
                    result = new T[]
                    {
                        converter(str)
                    };
                }
                else
                {
                    T[] array = new T[str.CountOccurences(',', num, str.Length - num) + 1];
                    int num3 = 0;
                    while (num2 != -1)
                    {
                        array[num3] = converter(str.Substring(num, num2 - num));
                        num = num2 + 1;
                        num2 = str.IndexOf(',', num);
                        num3++;
                    }
                    array[num3] = converter(str.Substring(num, str.Length - num));
                    result = array;
                }
            }
            return result;
        }
        public Burning.DofusProtocol.Network.Types.EntityLook GetEntityLook()
        {

            List<uint> currentSkins = new List<uint>();
            foreach (var skin in Skins)
            {
                currentSkins.Add((uint)skin);
            }

            List<int> currentScales = new List<int>();
            foreach (var scale in Scales)
            {
                currentScales.Add((int)scale);
            }

            Burning.DofusProtocol.Network.Types.EntityLook entity = new Burning.DofusProtocol.Network.Types.EntityLook()
            {
                bonesId = (uint)BonesID,
                scales = currentScales,
                skins = currentSkins,
                subentities = SubLooks.Select(e => e.GetSubEntity()).ToList(),
                indexedColors = Colors.Select(entry => entry.Value + (16777216 * entry.Key)).ToList(),
            };
            return entity;
        }
        #endregion

        #region Methods
        public void UpdateColor(int index, int color)
        {
            _colors[index] = color;
        }
        public void RemoveColor(int index)
        {
            _colors.Remove(index);
        }
        public void AddSkin(uint skin)
        {
            if (!_skins.Contains(skin))
                _skins.Add(skin);
        }
        public void RemoveSkin(uint skin)
        {
            _skins.Remove(skin);
        }

        public byte[] GetDatas()
        {
            var writer = new BigEndianWriter();
            int count = 0;

            writer.WriteShort((short)_colors.Count);
            foreach (var item in _colors)
            {
                writer.WriteInt(item.Key);
                writer.WriteInt(item.Value);
            }
            writer.WriteShort((short)_scales.Count);
            foreach (var item in _scales)
            {
                writer.WriteInt(item);
            }
            writer.WriteShort((short)_skins.Count);
            foreach (var item in _skins)
            {
                writer.WriteUInt(item);
            }
            writer.WriteShort((short)_subLooks.Count);
            for (int i = 0; i < count; i++)
            {

            }
            writer.WriteUInt(_bonesID);
            writer.WriteByte((byte)_binding);

            return writer.Data;
        }
        #endregion
    }
}
