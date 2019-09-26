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
    public class GuildRepository : SingletonManager<GuildRepository>, IRepository<Guild>
    {
        public IMongoCollection<Guild> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<Guild>(dataName);

            //load members
            GuildMemberRepository.Instance.Initialize("guild_members");
        }

        public void Insert(Guild entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(Guild entity)
        {
            var updateFields = Builders<Guild>.Update.Set("Level", entity.Level).Set("Experience", entity.Experience).Set("Bulletin", entity.Bulletin)
                .Set("Announce", entity.Announce);

            this.Collection.UpdateOne(Builders<Guild>.Filter.Eq("_id", entity.Id), updateFields);
        }

        public Guild GetGuildById(int id)
        {
            return this.Collection.Find(Builders<Guild>.Filter.Eq("_id", id)).Limit(1).FirstOrDefault();
        }

        public bool IsNameAlreadyExist(string name)
        {
            var guild = this.Collection.Find(Builders<Guild>.Filter.Eq("Name", name)).Limit(1).FirstOrDefault();

            if (guild != null)
                return true;

            return false;
        }
    }
}
