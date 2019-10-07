using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class SpellRepository : SingletonManager<SpellRepository>, IRepository<Spell>
    {
        public IMongoCollection<Spell> Collection { get; set; }

        public List<Spell> spells;

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<Spell>(dataName);
            this.spells = new List<Spell>();
            SpellLevelRepository.Instance.Initialize("spells_levels");
        }

        public Spell GetSpellById(int spellId)
        {
            var spell = this.spells.Find(x => x.Id == spellId);

            if(spell == null)
            {
                spell = this.Collection.Find(Builders<Spell>.Filter.Eq("_id", spellId)).Limit(1).FirstOrDefault();

                if (spell != null)
                    this.spells.Add(spell);
            }
            return spell;
        }

        public void Insert(Spell entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Spell entity)
        {
            throw new NotImplementedException();
        }
    }
}
