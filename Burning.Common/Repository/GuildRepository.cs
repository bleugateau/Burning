using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class GuildRepository : SingletonManager<GuildRepository>, InterfaceTest<Guild>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<Guild> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = this.Accessor.Fill<Guild>();

            Console.WriteLine("{0} guild(s) loaded.", this.List.Count);
        }

        public void Add(Guild guild)
        {
            var query = "INSERT INTO " + this.TableName + " (ownerCharacterId, name, level, experience, annouce, bulletin, symbolShape, symbolColor, backgroundShape, backgroundColor, creationDate) " +
               "VALUES(@OwnerCharacterId, @Name, @Level, @Experience, @Announce, @Bulletin, @SymbolShape, @SymbolColor, @BackgroundShape, @BackgroundColor, @CreationDate)";

            DbAccessor.World.Execute(query, guild);
        }

        public void Update(Guild guild)
        {
            var query = "UPDATE " + this.TableName + " SET level=@Level, experience=@Experience, bulletin=@Bulletin, announce=@Announce WHERE id=@Id";
            DbAccessor.World.Execute(query, guild);
        }
    }
}
