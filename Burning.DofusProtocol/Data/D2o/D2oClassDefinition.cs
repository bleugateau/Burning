using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Burning.DofusProtocol.Data.D2o
{
    [DebuggerDisplay("Name = {" + nameof(Name) + "}")]
    public class D2oClassDefinition
    {
        public D2oClassDefinition(int id, string classname, string packagename, Type classType,
            IEnumerable<D2oFieldDefinition> fields, long offset)
        {
            Id = id;
            Name = classname;
            PackageName = packagename;
            ClassType = classType;
            Fields = fields.ToDictionary(entry => entry.Name);
            Offset = offset;
        }

        public Dictionary<string, D2oFieldDefinition> Fields { get; }

        public int Id { get; }

        public string Name { get; }

        public string PackageName { get; }

        public Type ClassType { get; }

        internal long Offset { get; set; }
    }
}
