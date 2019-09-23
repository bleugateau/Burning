using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class BreedRepository : SingletonManager<BreedRepository>, InterfaceTest<Breed>
    {
        private static string tableName = "breeds";
        public static string Table { get { return tableName; } }

        public RepositoryAccessor Accessor { get; set; }
        public string TableName { get; set; }
        public List<Burning.DofusProtocol.Datacenter.Breed> List { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            //this.List = this.Accessor.Fill<Breed>();

            this.List = new List<Burning.DofusProtocol.Datacenter.Breed>();

            D2oReader reader = new D2oReader("common/"+this.TableName+".d2o");
            for (int i = 1; i < reader.IndexCount + 1; i++)
            {
                this.List.Add((Burning.DofusProtocol.Datacenter.Breed)reader.ReadObject(i));
            }
            reader.Close();
        }
    }
}
