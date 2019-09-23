using System;

namespace Burning.DofusProtocol.Data.D2o
{
    public class D2oFieldAttribute : Attribute
    {
        public D2oFieldAttribute()
        {
        }

        public D2oFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; set; }
    }
}
