using System;

namespace Burning.DofusProtocol.Data.D2o
{
    public class D2oClassAttribute : Attribute
    {
        public D2oClassAttribute(string name, bool autoBuild = true)
        {
            Name = name;
            AutoBuild = autoBuild;
        }

        public D2oClassAttribute(string name, string packageName, bool autoBuild = true)
        {
            Name = name;
            PackageName = packageName;
            AutoBuild = autoBuild;
        }

        public string Name { get; set; }

        public string PackageName { get; set; }

        public bool AutoBuild { get; set; }
    }
}
