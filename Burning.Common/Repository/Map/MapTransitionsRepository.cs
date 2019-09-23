using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class MapTransitionsRepository : SingletonManager<MapTransitionsRepository>, InterfaceTest<MapTransition>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<MapTransition> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = this.Accessor.Fill<MapTransition>();
        }
    }
}
