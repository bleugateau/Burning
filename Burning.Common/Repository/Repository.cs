using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Burning.Common.Repository
{
    public class Repository
    {
        public string Table { get { return tableName; } }
        public dynamic Obj;
        public DbTypeEnum DbTypeEnum { get; set; }
        private string tableName { get; set; }
        private Task task { get; set; }
        public Repository() { }

        public void TaskTest(object obj)
        {
            dynamic t = Convert.ChangeType(obj, obj.GetType());

            /*
            if(t.Id != 0)
            {
                Task.

                //this.task.IsCompleted = true;
            }
            */

        }

        public void Initialize(object obj, DbTypeEnum dbTypeEnum)
        {
            this.DbTypeEnum = dbTypeEnum;

            this.task = Task.Run(() => this.TaskTest(obj));
            task.Wait();

            Console.WriteLine("fin de ma task");

            try
            {
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(asm => asm.GetName().Name == "Burning.Common");
                foreach (var type in assembly.GetTypes().Where(x => x.IsClass == true))
                {
                    if (type.Namespace == null)
                        continue;

                    if (!type.Namespace.Contains("Burning.Common.Entity") || type.FullName != obj.GetType().FullName)
                        continue;

                    FieldInfo table = type.GetField("Table");

                    if (table != null)
                    {
                        this.tableName = (string)table.GetValue(type);

                        this.Obj = Convert.ChangeType(obj, type);

                        Console.WriteLine(this.Obj.GetType());
                        Console.WriteLine(this.Obj.Id);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<T> Add<T>()
        {
            var query = "SELECT * FROM " + this.tableName;
            return DbAccessor.World.Query<T>(query);
        }

        public void Delete()
        {
            var query = "DELETE FROM " + this.tableName + " WHERE id=@Id";

            if (this.DbTypeEnum == DbTypeEnum.AUTH)
                DbAccessor.Auth.Execute(query, new {Id = this.Obj.Id});
            else
                DbAccessor.World.Execute(query, new { Id = this.Obj.Id });
        }
    }
}
