using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class GuildMemberRepository : SingletonManager<GuildMemberRepository>, InterfaceTest<GuildMember>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<GuildMember> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = this.Accessor.Fill<GuildMember>();

            Console.WriteLine("{0} guild(s) member loaded.", this.List.Count);
        }

        public void Add(GuildMember guild)
        {
            var query = "INSERT INTO " + this.TableName + " (guildId, characterId, role, possessedRight, pourcentageXpGiven) " +
               "VALUES(@GuildId, @CharacterId, @Role, @PossessedRight, @PourcentageXpGiven)";

            DbAccessor.World.Execute(query, guild);
        }

        public void Update(GuildMember guild)
        {
            var query = "UPDATE " + this.TableName + " SET role=@Role, possessedRight=@PossessedRight, pourcentageXpGiven=@PourcentageXpGiven WHERE id=@Id";
            DbAccessor.World.Execute(query, guild);
        }
    }
}
