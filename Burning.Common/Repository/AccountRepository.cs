using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public static class AccountRepository
    {
        private static string tableName = "accounts";
        public static string Table { get { return tableName; } }

        public static void Update(Account account)
        {
            var query = "UPDATE "+ Table +" SET ticket = @Ticket, isBanned = @IsBanned WHERE id = @Id";
            DbAccessor.Auth.Execute(query, account);
        }

        public static Account GetAccountByLogin(string login)
        {
            var query = "SELECT * FROM " + Table + " WHERE login = @Login";
            List<Account> accountsList = DbAccessor.Auth.Query<Account>(query, new { Login = login });
            return accountsList.Count > 0 ? accountsList[0] : null;
        }

        public static Account GetAccountByTicket(string ticket)
        {
            var query = "SELECT * FROM " + Table + " WHERE ticket = @Ticket";
            List<Account> accountsList = DbAccessor.Auth.Query<Account>(query, new { Ticket = ticket });
            return accountsList.Count > 0 ? accountsList[0] : null;
        }
    }
}
