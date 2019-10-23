using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Burning.D2oSync
{
    class Program
    {
        public static D2oReader Reader { get; set; }
        public static IMongoDatabase Database { get; set; }

        public static string BasePath = @"D:\Program Files (x86)\Ankama\Dofus\Dofus 2.53 patché\data\common\";

        static void Main(string[] args)
        {
            Database = new MongoClient("mongodb://localhost").GetDatabase("burning_datacenter253");
            GetDindeXpMapping();

            Console.ReadKey();
        }

        public static void GetDindeXpMapping()
        {
            int oldValue = 450;
            for(int i = 1; i < 201; i++)
            {
                int result = oldValue + 250;
                oldValue = result;
                Console.WriteLine("LVL {0} XP necessaire {1}", i, result);
            }
        }

        public static void GetJobXpMapping(string basePath)
        {
            int baseValue = 0;
            int oldBaseValue = 0;

            for(int i = 1; i < 201; i++)
            {
                int result = baseValue + (baseValue - oldBaseValue) + 20;
                if (i == 1)
                {
                    result = 20;
                }

                oldBaseValue = baseValue;
                baseValue = result;

                Console.WriteLine("LVL {0} XP necessaire {1}", i, result);
            }
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

        public static void GetBreeds(string basePath)
        {
            Reader = new D2oReader(basePath + "Breeds.d2o");

            var collection = Database.GetCollection<Breed>("breeds");
            if (collection == null)
            {
                Database.CreateCollection("breeds");
                collection = Database.GetCollection<Breed>("breeds");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                counter++;
                collection.InsertOne((Breed)item.Value);
                Console.WriteLine("breed {0}/{1} added.", counter, Reader.IndexCount);
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

        public static void GetSpellsLevels(string basePath)
        {
            Reader = new D2oReader(basePath + "SpellLevels.d2o");

            var collection = Database.GetCollection<SpellLevel>("spells_levels");
            if (collection == null)
            {
                Database.CreateCollection("spells_levels");
                collection = Database.GetCollection<SpellLevel>("spells_levels");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                try
                {
                    collection.InsertOne((SpellLevel)item.Value);
                    counter++;
                    Console.WriteLine("spells levels {0}/{1} added.", counter, Reader.IndexCount);
                }
                catch
                {
                    Console.WriteLine("error try again");
                }
            }

            Console.WriteLine("Collection generated :)");

            Console.ReadKey();


        }

        public static void GetSpellsVariants(string basePath)
        {
            Reader = new D2oReader(basePath + "SpellVariants.d2o");

            var collection = Database.GetCollection<SpellVariant>("spells_variants");
            if (collection == null)
            {
                Database.CreateCollection("spells_variants");
                collection = Database.GetCollection<SpellVariant>("spells_variants");
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                counter++;
                collection.InsertOne((SpellVariant)item.Value);
                Console.WriteLine("spells variants {0}/{1} added.", counter, Reader.IndexCount);
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
