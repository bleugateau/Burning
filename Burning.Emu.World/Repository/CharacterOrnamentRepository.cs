using Burning.Common.Entity;
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
    public class CharacterOrnamentRepository : SingletonManager<CharacterOrnamentRepository>, IRepository<CharacterOrnament>
    {
        public IMongoCollection<CharacterOrnament> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<CharacterOrnament>(dataName);
        }

        public void Insert(CharacterOrnament entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(CharacterOrnament entity)
        {
            throw new NotImplementedException();
        }

        public List<CharacterOrnament> GetOrnamentsByCharacter(Character character)
        {
            return this.Collection.Find(Builders<CharacterOrnament>.Filter.Eq("CharacterId", character.Id)).ToList();
        }
    }
}
