using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class NpcRepository : SingletonManager<NpcRepository>, InterfaceTest<Npc>
    {
        public RepositoryAccessor Accessor { get; set; }
        public string TableName { get; set; }
        public List<Npc> List { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            //this.List = this.Accessor.Fill<Breed>();

            this.List = new List<Npc>();

            D2oReader reader = new D2oReader("common/" + this.TableName + ".d2o");
            foreach (var npc in reader.ReadObjects())
            {
                this.List.Add((Npc)npc.Value);
            }
            reader.Close();
        }

        public Npc GetNpcFromId(int npcId)
        {
            return this.List.Find(x => x.Id == npcId);
        }
    }
}