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
        //public List<Character> List { get; set; }

        public IMongoCollection<Character> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<Character>(dataName);

            //load other repos
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

        /*
public void Initialize(string tableName)
{
   this.TableName = tableName;
   this.Accessor = new RepositoryAccessor(this.TableName);
   this.List = this.Accessor.Fill<Character>();

   CharacterOrnamentRepository.Instance.Initialize("characters_ornaments");
   Console.WriteLine("{0} character(s) ornaments loaded", CharacterOrnamentRepository.Instance.List.Count);

   CharacterTitleRepository.Instance.Initialize("characters_titles");
   Console.WriteLine("{0} character(s) titles loaded", CharacterTitleRepository.Instance.List.Count);
}

public void Add(Character character)
{
   var query = "INSERT INTO " + this.TableName + " (id, accountId, name, entityLook, sex, breed, level, experience, kamas, mapId, cellId) " +
      "VALUES(@Id, @AccountId, @Name, @EntityLook, @Sex, @Breed, @Level, @Experience, @Kamas, @MapId, @CellId)";

   DbAccessor.World.Execute(query, character);
}

public static List<Character> FillCharacters()
{
   var query = "SELECT * FROM " + Table;
   return DbAccessor.World.Query<Character>(query);
}


public static void Update(Character character)
{
   var query = "UPDATE " + Table + " SET entityLook=@EntityLook, level=@Level, experience=@Experience, kamas=@Kamas, mapId=@MapId, cellId=@Cellid, activeTitle=@ActiveTitle, activeOrnament=@ActiveOrnament WHERE id=@Id";
   DbAccessor.World.Execute(query, character);
}

public static void Delete(Character character)
{
   var query = "DELETE FROM " + Table + " WHERE id=@Id";
   DbAccessor.World.Execute(query, character);
}

public static List<Character> GetCharactersByAccountId(int accountId)
{
   var query = "SELECT * FROM " + Table + " WHERE accountId = @AccountId";
   List<Character> charactersList = DbAccessor.World.Query<Character>(query, new { AccountId = accountId });
   return charactersList;
}

public static bool CheckIfNameAlreadyExist(string name)
{
   var query = "SELECT * FROM " + Table + " WHERE name = @Name";
   List<Character> charactersList = DbAccessor.World.Query<Character>(query, new { Name = name });
   return charactersList.Count > 0 ? true : false;
}

public static bool CheckIfAllowedToMakeCharacterByAccountId(int accountId)
{
   var query = "SELECT * FROM " + Table + " WHERE accountId = @AccountId";
   List<Character> charactersList = DbAccessor.World.Query<Character>(query, new { AccountId = accountId });
   return charactersList.Count >= 3 ? false : true;
}
*/
    }
}
