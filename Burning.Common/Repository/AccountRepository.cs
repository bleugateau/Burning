using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class AccountRepository : SingletonManager<AccountRepository>, IRepository<Account>
    {
        public IMongoCollection<Account> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.Realm.GetCollection<Account>(dataName);
        }

        public void Insert(Account entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(Account entity)
        {
            var updateFields = Builders<Account>.Update.Set("Ticket", entity.Ticket);
            this.Collection.UpdateOne(Builders<Account>.Filter.Eq(x => x.Id, entity.Id), updateFields);
        }

        public Account GetAccountByLogin(string login)
        {
            return this.Collection.Find(Builders<Account>.Filter.Eq("Login", login)).Limit(1).FirstOrDefault();
        }

        public Account GetAccountByTicket(string ticket)
        {
            return this.Collection.Find(Builders<Account>.Filter.Eq("Ticket", ticket)).Limit(1).FirstOrDefault();
        }
    }
}
