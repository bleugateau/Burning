using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.D2oSync
{
    class Program
    {
        public static D2oReader Reader { get; set; }
        public static IMongoDatabase Database { get; set; }

        public static string BasePath = @"C:\Users\tenfo\Desktop\Dofus 2.52\data\common\";

        static void Main(string[] args)
        {
            Database = new MongoClient("mongodb://localhost").GetDatabase("burning_datacenter");
            GetMonsters(BasePath);
        }

        public static void GetNpcs(string basePath)
        {
            Reader = new D2oReader(basePath + "Npcs.d2o");

            var collection = Database.GetCollection<Npc>("npcs");
            if (collection == null)
            {
                Database.CreateCollection("npcs");
                collection = Database.GetCollection<Npc>("npcs");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                counter++;
                collection.InsertOne((Npc)item.Value);
                Console.WriteLine("Npcs {0}/{1} added.", counter, Reader.IndexCount);
            }

            Console.WriteLine("Collection generated :)");

            Console.ReadKey();

        }

        public static void GetSpells(string basePath)
        {
            Reader = new D2oReader(basePath + "Spells.d2o");

            var collection = Database.GetCollection<Spell>("spells");
            if (collection == null)
            {
                Database.CreateCollection("spells");
                collection = Database.GetCollection<Spell>("spells");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                counter++;
                collection.InsertOne((Spell)item.Value);
                Console.WriteLine("spells {0}/{1} added.", counter, Reader.IndexCount);
            }

            Console.WriteLine("Collection generated :)");

            Console.ReadKey();
        }

        public static void GetMonsters(string basePath)
        {
            Reader = new D2oReader(basePath + "Monsters.d2o");

            var collection = Database.GetCollection<Monster>("monsters");
            if (collection == null)
            {
                Database.CreateCollection("monsters");
                collection = Database.GetCollection<Monster>("monsters");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                try
                {
                    counter++;
                    collection.InsertOne((Monster)item.Value);
                    Console.WriteLine("monsters {0}/{1} added.", counter, Reader.IndexCount);
                }
                catch
                {

                }
                
            }

            Console.WriteLine("Collection generated :)");

            Console.ReadKey();
        }

        public static void GetItems(string basePath)
        {
            Reader = new D2oReader(basePath + "Items.d2o");

            var collection = Database.GetCollection<Item>("items");
            if (collection == null)
            {
                Database.CreateCollection("items");
                collection = Database.GetCollection<Item>("items");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                if (!item.Value.GetType().Name.Contains("Item"))
                    continue;

                counter++;
                collection.InsertOne((Item)item.Value);
                Console.WriteLine("items {0}/{1} added.", counter, Reader.IndexCount);
            }

            Console.WriteLine("Collection generated :)");

            Console.ReadKey();
        }
    }
}
