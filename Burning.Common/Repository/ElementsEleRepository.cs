using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class ElementsEleRepository : SingletonManager<ElementsEleRepository>, InterfaceTest<ElementEle>
    {
        private static string tableName = "elements_ele";
        public static string Table { get { return tableName; } }

        public RepositoryAccessor Accessor { get; set; }
        public string TableName { get; set; }
        public List<ElementEle> List { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = this.Accessor.Fill<ElementEle>();
        }
    }
}
