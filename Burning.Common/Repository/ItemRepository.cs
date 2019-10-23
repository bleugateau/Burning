using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class ItemRepository : SingletonManager<ItemRepository>, IRepository<Item>
    {
        public IMongoCollection<Item> Collection { get; set; }

        public List<Item> List { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<Item>(dataName);
            this.List = new List<Item>();
        }

        public void Insert(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }

        public Item GetItemDataById(int id)
        {
            var item = this.List.Find(x => x != null && x.id == id);

            if (item == null)
            {
                item = this.Collection.Find(Builders<Item>.Filter.Eq("_id", id)).Limit(1).FirstOrDefault();
                this.List.Add(item);
            }
            return item;
        }
    }
}
