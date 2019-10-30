using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class EffectRepository : SingletonManager<EffectRepository>, IRepository<Effect>
    {
        public IMongoCollection<Effect> Collection { get; set; }

        private List<Effect> Effects;

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<Effect>(dataName);
            this.Effects = this.Collection.Find(_ => true).ToList();
        }

        public Effect GetEffect(int id)
        {
            return this.Effects.Find(x => x.Id == id);
        }

        public void Insert(Effect entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Effect entity)
        {
            throw new NotImplementedException();
        }
    }
}
