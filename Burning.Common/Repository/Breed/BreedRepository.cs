using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class BreedRepository : SingletonManager<BreedRepository>, IRepository<Breed>
    {
        public IMongoCollection<Breed> Collection { get; set; }

        private List<Breed> Breeds { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<Breed>(dataName);
            this.Breeds = this.Collection.Find(_ => true).ToList();
        }

        public Breed GetBreedById(int breedId)
        {
            return this.Breeds.Find(x => x.Id == breedId);
        }

        public void Insert(Breed entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Breed entity)
        {
            throw new NotImplementedException();
        }
    }
}
