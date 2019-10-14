using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.DofusProtocol.Datacenter;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class NpcSpawnRepository : SingletonManager<NpcSpawnRepository>, IRepository<NpcSpawn>
    {
        public IMongoCollection<NpcSpawn> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<NpcSpawn>(dataName);
            NpcRepository.Instance.Initialize("npcs");
        }

        public void Insert(NpcSpawn entity)
        {
            throw new NotImplementedException();
        }

        public void Update(NpcSpawn entity)
        {
            throw new NotImplementedException();
        }

        public List<NpcSpawn> GetNpcSpawnsFromMapId(int mapId, bool lazy = true)
        {
            var npcs = this.Collection.Find(Builders<NpcSpawn>.Filter.Eq("MapId", mapId)).ToList();


            foreach (var npc in npcs)
            {
                Npc npcData = NpcRepository.Instance.GetNpcFromId((int)npc.NpcId, lazy);
                if (npcData != null)
                {
                    npc.EntityLook = npcData.Look;
                }

            }

            return npcs;
        }
    }
}
