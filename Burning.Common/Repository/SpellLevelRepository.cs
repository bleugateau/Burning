using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class SpellLevelRepository : SingletonManager<SpellLevelRepository>, IRepository<SpellLevel>
    {
        public IMongoCollection<SpellLevel> Collection { get; set; }

        private List<SpellLevel> spellLevels;

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<SpellLevel>(dataName);
            this.spellLevels = new List<SpellLevel>();
        }

        public SpellLevel GetSpellLevelById(int spellLevelId)
        {
            var spellLevel = this.spellLevels.Find(x => x.Id == spellLevelId);

            if(spellLevel == null)
            {
                spellLevel = this.Collection.Find(Builders<SpellLevel>.Filter.Eq("_id", spellLevelId)).Limit(1).FirstOrDefault();

                if(spellLevel != null)
                    this.spellLevels.Add(spellLevel);
            }

            return spellLevel;
        }

        public void Insert(SpellLevel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SpellLevel entity)
        {
            throw new NotImplementedException();
        }
    }
}
