using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class MapStatedElementRepository : SingletonManager<MapStatedElementRepository>, IRepository<MapStatedElement>
    {
        public IMongoCollection<MapStatedElement> Collection { get; set; }

        private List<MapStatedElement> mapStatedElements;

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<MapStatedElement>(dataName);
            this.mapStatedElements = new List<MapStatedElement>();
        }

        public List<MapStatedElement> GetMapStatedElementsFromMapId(int mapId)
        {
            var statedElements = this.mapStatedElements.FindAll(x => x != null && x.MapId == mapId);

            if(statedElements.Count == 0)
            {
                statedElements = this.Collection.Find(Builders<MapStatedElement>.Filter.Eq("MapId", mapId)).ToList();
                this.mapStatedElements.AddRange(statedElements);
            }

            return statedElements;
        }

        public void Insert(MapStatedElement entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MapStatedElement entity)
        {
            throw new NotImplementedException();
        }
    }
}
