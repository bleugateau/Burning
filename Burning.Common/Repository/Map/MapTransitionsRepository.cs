using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class MapTransitionsRepository : SingletonManager<MapTransitionsRepository>, IRepository<MapTransition>
    {
        public IMongoCollection<MapTransition> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<MapTransition>(dataName);
        }

        public void Insert(MapTransition entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MapTransition entity)
        {
            throw new NotImplementedException();
        }

        public MapTransition GetTransitionFromMapId(int mapId, int mapNeighbour)
        {
            var filters = Builders<MapTransition>.Filter.Eq("MapIdRequested", mapId) & Builders<MapTransition>.Filter.Eq("FromNeighbour", mapNeighbour);
            return this.Collection.Find(filters).Limit(1).FirstOrDefault();
        }
    }
}
