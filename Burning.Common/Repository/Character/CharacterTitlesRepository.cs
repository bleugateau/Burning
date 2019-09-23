using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class CharacterTitleRepository : SingletonManager<CharacterTitleRepository>, InterfaceTest<CharacterTitle>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<CharacterTitle> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = this.Accessor.Fill<CharacterTitle>();
        }
    }
}
