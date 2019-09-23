using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class NpcSpawnRepository : SingletonManager<NpcSpawnRepository>, InterfaceTest<NpcSpawn>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<NpcSpawn> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            //this.List = this.GetNpcSpawnsFromMapId(88081176);
        }

        public List<NpcSpawn> GetNpcSpawnsFromMapId(int mapId)
        {
            var query = "SELECT * FROM " + this.TableName + " WHERE mapId=@MapId";
            var npcs = DbAccessor.World.Query<NpcSpawn>(query, new { MapId = mapId });

            foreach(var npc in npcs)
            {
                Npc npcData = NpcRepository.Instance.GetNpcFromId((int)npc.NpcId);
                if (npcData != null)
                {
                    npc.EntityLook = npcData.Look;
                    //npc.Gender = bool.Parse(npcData.Gender.ToString());
                }
                    
            }

            return npcs;
        }
    }
}
