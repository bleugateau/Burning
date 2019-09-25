using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2o;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class HeadRepository : SingletonManager<HeadRepository>, InterfaceTest<Burning.DofusProtocol.Datacenter.Head>
    {
        
        //public RepositoryAccessor Accessor { get; set; }
        public string TableName { get; set; }
        public List<Burning.DofusProtocol.Datacenter.Head> List { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            //this.Accessor = new RepositoryAccessor(this.TableName);

            this.List = new List<Burning.DofusProtocol.Datacenter.Head>();

            D2oReader reader = new D2oReader("common/"+this.TableName+".d2o");
            for (int i = 1; i < reader.IndexCount + 1; i++)
            {
                try
                {
                    this.List.Add((Burning.DofusProtocol.Datacenter.Head)reader.ReadObject(i));
                }
                catch
                {
                    
                }
            }
            reader.Close();
        }
    }
}
