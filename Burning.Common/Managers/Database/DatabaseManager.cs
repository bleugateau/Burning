using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Burning.Common.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace Burning.Common.Managers.Database
{
    public class DatabaseManager
    {

        public IDbConnection dbConnection;
        public bool IsInitialized = false;
        private string DatabaseName = "";

        public void Initialize(string host, string databaseName, string username, string password)
        {
            if (IsInitialized)
                return;

            MySqlConnectionStringBuilder sConnB = new MySqlConnectionStringBuilder()
            {
                Server = host,
                Database = databaseName,
                UserID = username,
                Password = password
            };

            dbConnection = new MySqlConnection(sConnB.ConnectionString);
            try
            {
                dbConnection.Open();
                DatabaseName = databaseName;
                Console.WriteLine("Database {0} initialized !", DatabaseName);
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DATABASE] {0}", ex.ToString());
            }
        }

        public bool Exist<T>(string tableName, IEntity obj)
        {
            var query = "SELECT * FROM " + tableName + " WHERE id=@Id";
            List<T> list = this.Query<T>(query, new {Id = obj.Id });
            return list.Count > 0 ? true : false;
        }

        public List<T> Query<T>(string query, object param = null)
        {
            return new List<T>(dbConnection.Query<T>(query, param));
        }

        public void Execute(string query, object param = null)
        {
            dbConnection.Execute(query, param);
        }

        public void Close()
        {
            if (!IsInitialized)
                return;

            dbConnection.Close();
            Console.WriteLine("Database {0} closed !", DatabaseName);
            IsInitialized = false;
        }
    }
}
