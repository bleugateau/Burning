using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class MapPositionRepository : SingletonManager<MapPositionRepository>
    {
        //public RepositoryAccessor Accessor { get; set; }
        public List<MapPosition> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.List = new List<MapPosition>();


            D2oReader reader = new D2oReader("common/" + this.TableName + ".d2o");

            foreach (var obj in reader.ReadObjects())
            {
                this.List.Add((MapPosition)obj.Value);
            }

            reader.Close();

            Console.WriteLine("{0} map positions loaded from d2o.", this.List.Count);
        }
    }
}