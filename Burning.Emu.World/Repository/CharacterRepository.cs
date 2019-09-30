using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class CharacterRepository : SingletonManager<CharacterRepository>, IRepository<Character>
    {
        public IMongoCollection<Character> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<Character>(dataName);

            //load other repos
            CharacterCharacteristicRepository.Instance.Initialize("character_characteristics");
            CharacterOrnamentRepository.Instance.Initialize("character_ornaments");
            CharacterTitleRepository.Instance.Initialize("character_titles");
        }

        public void Insert(Character entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(Character entity)
        {
            var updateFields = Builders<Character>.Update.Set("EntityLook", entity.EntityLook)
                .Set("Level", entity.Level).Set("Experience", entity.Experience).Set("Kamas", entity.Kamas)
                .Set("CellId", entity.CellId).Set("MapId", entity.MapId).Set("ActiveTitle", entity.ActiveTitle)
                .Set("ActiveOrnament", entity.ActiveOrnament);

            this.Collection.UpdateOne(Builders<Character>.Filter.Eq(x => x.Id, entity.Id), updateFields);
        }

        public List<Character> GetCharactersByAccountId(int accountId)
        {
            return this.Collection.Find(Builders<Character>.Filter.Eq("AccountId", accountId)).ToList();
        }

        public Character GetCharacterById(int characterId)
        {
            return this.Collection.Find(Builders<Character>.Filter.Eq("_id", characterId)).Limit(1).FirstOrDefault();
        }
    }
}
