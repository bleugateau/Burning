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
    class MapInteractiveElementRepository : SingletonManager<MapInteractiveElementRepository>, IRepository<MapInteractiveElement>
    {
        public IMongoCollection<MapInteractiveElement> Collection { get; set; }

        private List<MapInteractiveElement> mapInteractiveElements;

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<MapInteractiveElement>(dataName);
            this.mapInteractiveElements = new List<MapInteractiveElement>();
        }

        public List<MapInteractiveElement> GetMapInteractiveElementsFromMapId(int mapId)
        {
            var interactiveElements = this.mapInteractiveElements.FindAll(x => x != null && x.MapId == mapId);

            if (interactiveElements.Count == 0)
            {
                interactiveElements = this.Collection.Find(Builders<MapInteractiveElement>.Filter.Eq("MapId", mapId)).ToList();
                this.mapInteractiveElements.AddRange(interactiveElements);
            }

            return interactiveElements;
        }

        public void Insert(MapInteractiveElement entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MapInteractiveElement entity)
        {
            throw new NotImplementedException();
        }
    }
}
