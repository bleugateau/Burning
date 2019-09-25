using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class GuildMemberRepository : SingletonManager<GuildMemberRepository>, IRepository<GuildMember>
    {

        public IMongoCollection<GuildMember> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<GuildMember>(dataName);
        }

        public void Insert(GuildMember entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(GuildMember entity)
        {
            //"UPDATE " + this.TableName + " SET role=@Role, possessedRight=@PossessedRight, pourcentageXpGiven=@PourcentageXpGiven WHERE id=@Id";
            var updateFields = Builders<GuildMember>.Update.Set("Role", entity.Role).Set("PossessedRight", entity.PossessedRight).Set("PourcentageXpGiven", entity.PourcentageXpGiven);

            this.Collection.UpdateOne(Builders<GuildMember>.Filter.Eq("_id", entity.Id), updateFields);
        }

        public List<GuildMember> GetGuildMembersFromGuildId(int guildId)
        {
            return this.Collection.Find(Builders<GuildMember>.Filter.Eq("GuildId", guildId)).ToList();
        }

        public GuildMember GetGuildMemberFromCharacterId(int characterId)
        {
            return this.Collection.Find(Builders<GuildMember>.Filter.Eq("CharacterId", characterId)).Limit(1).FirstOrDefault();
        }
    }
}
