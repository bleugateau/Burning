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
    public class CharacterTitleRepository : SingletonManager<CharacterTitleRepository>, IRepository<CharacterTitle>
    {
        public IMongoCollection<CharacterTitle> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<CharacterTitle>(dataName);
        }

        public void Insert(CharacterTitle entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(CharacterTitle entity)
        {
            throw new NotImplementedException();
        }

        public List<CharacterTitle> GetTitlesByCharacter(Character character)
        {
            return this.Collection.Find(Builders<CharacterTitle>.Filter.Eq("CharacterId", character.Id)).ToList();
        }
    }
}
