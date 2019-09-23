using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Common.Repository
{
    public class CharacterRepository : SingletonManager<CharacterRepository>, InterfaceTest<Character>
    {
        public static string Table = "characters";
        public RepositoryAccessor Accessor { get; set; }
        public string TableName { get; set; }
        public List<Character> List { get; set; }

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
    }
}
