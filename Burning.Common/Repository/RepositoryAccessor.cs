using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public class RepositoryAccessor
    {
        public string TableName { get; set; }
        public dynamic Object { get; set; }

        public RepositoryAccessor(string tableName)
        {
            this.TableName = tableName;
        }

        public int LastId<T>(List<T> list)
        {
            if (list.Count <= 0)
                return 0;

            var lol = list[list.Count - 1];
            dynamic test = Convert.ChangeType(list[list.Count - 1], lol.GetType());
            return test.Id;
        }

        public List<T> Fill<T>()
        {
            var query = "SELECT * FROM " + this.TableName;
            return DbAccessor.World.Query<T>(query);
        }

        public void Delete<T>(T obj)
        {
            var query = "DELETE FROM " + this.TableName + " WHERE id=@Id";
            DbAccessor.World.Execute(query, obj);
        }
    }
}
