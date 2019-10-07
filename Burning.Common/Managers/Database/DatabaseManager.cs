using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Network.Types;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Managers.Database
{
    public class DatabaseManager : SingletonManager<DatabaseManager>
    {
        public MongoClient MongoClient { get; set; }

        public IMongoDatabase Realm { get; set; }

        public IMongoDatabase World { get; set; }

        public IMongoDatabase DataCenter { get; set; }


        public void Initialize(string connectionString)
        {
            this.MongoClient = new MongoClient(connectionString);
            this.Realm = this.MongoClient.GetDatabase("burning");
            this.World = this.MongoClient.GetDatabase("burning_world");
            this.DataCenter = this.MongoClient.GetDatabase("burning_datacenter253");

            BsonClassMap.RegisterClassMap<EffectInstanceDice>();
            BsonClassMap.RegisterClassMap<ObjectEffectInteger>();
            BsonClassMap.RegisterClassMap<ShortcutSpell>();
            BsonClassMap.RegisterClassMap<ShortcutObjectItem>();
            BsonClassMap.RegisterClassMap<ShortcutObjectIdolsPreset>();
            BsonClassMap.RegisterClassMap<ShortcutObjectPreset>();
        }

        public int AutoIncrement<T>(IMongoCollection<T> collection)
        {
            dynamic entity = collection.Find(Builders<T>.Filter.Gt("_id", 0)).Sort("{_id : -1}").Limit(1).FirstOrDefault();
            return (int)(entity != null ?  entity.Id + 1 : 1);
        }

        public void Delete<T>(IMongoCollection<T> collection, dynamic entity)
        {
            if (entity == null)
                return;

            collection.DeleteOne(Builders<T>.Filter.Eq("_id", entity.Id));
        }
    }
}
