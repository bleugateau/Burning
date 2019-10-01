using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class MonsterRepository : SingletonManager<MonsterRepository>, IRepository<Monster>
    {
        public IMongoCollection<Monster> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<Monster>(dataName);
        }

        public List<Monster> GetMonstersFromSubarea(uint subareaId)
        {
            return this.Collection.Find(x => x.FavoriteSubareaId == subareaId && x.IsMiniBoss == false && x.Spells.Count != 0).Limit(5).ToList();
        }

        public void Insert(Monster entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Monster entity)
        {
            throw new NotImplementedException();
        }
    }
}
