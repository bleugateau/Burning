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
            //SynchronizeD2o<Effect>("Effects");
            GetCharacterXpAndGuildMapping();
            GetDindeXpMapping();
            GetJobXpMapping();

            Console.ReadKey();
        }


        public static void SynchronizeD2o<T>(string d2oName, string nameOutput = "")
        {
            if (nameOutput == "")
                nameOutput = d2oName.ToLower();

            Reader = new D2oReader(BasePath + d2oName + ".d2o");

            var collection = Database.GetCollection<T>(nameOutput);
            if (collection == null)
            {
                Database.CreateCollection(nameOutput);
                collection = Database.GetCollection<T>(nameOutput);
            }

            int counter = 0;
            foreach (var item in Reader.ReadObjects())
            {
                counter++;
                collection.InsertOne((T)item.Value);
                Console.WriteLine("{0} {1}/{2} added.", d2oName, counter, Reader.IndexCount);
            }

            Console.WriteLine("Collection generated :)", nameOutput);
        }

        public static async Task ConvertListToCollection<T>(string nameCollection, List<T> objects)
        {

            var collection = Database.GetCollection<T>(nameCollection);
            if (collection != null)
                await Database.DropCollectionAsync(nameCollection);

            await Database.CreateCollectionAsync(nameCollection);

            collection = Database.GetCollection<T>(nameCollection);

            await collection.InsertManyAsync(objects);
            

            Console.WriteLine("Collection {0} is make from list of type: {1}", nameCollection, typeof(T).Name);
        }

        public static void GetCharacterXpAndGuildMapping()
        {
            Reader = new D2oReader(BasePath + "CharacterXPMappings.d2o");

            List<LevelDetail> charactersExp = new List<LevelDetail>();
            List<LevelDetail> guildExp = new List<LevelDetail>();

            foreach (var item in Reader.ReadObjects())
            {
                CharacterXPMapping content = (CharacterXPMapping)item.Value;
                charactersExp.Add(new LevelDetail(content.Level, content.ExperiencePoints));

                if(content.Level < 201)
                    guildExp.Add(new LevelDetail(content.Level, content.ExperiencePoints * 10));
            }

            Task.Run(async () => await ConvertListToCollection<LevelDetail>("characters_experiences", charactersExp)).Wait();
            Task.Run(async () => await ConvertListToCollection<LevelDetail>("guilds_experiences", guildExp)).Wait();


        }


        public static void GetDindeXpMapping()
        {
            List<LevelDetail> levelDetails = new List<LevelDetail>();
            levelDetails.Add(new LevelDetail(1, 0));
            int oldValue = 450;
            for(int i = 2; i < 101; i++)
            {
                int result = oldValue + 250;
                oldValue = result;
                Console.WriteLine("LVL {0} XP necessaire {1}", i, result);
                levelDetails.Add(new LevelDetail(i, result));
            }

            Task.Run(async () => await ConvertListToCollection<LevelDetail>("mounts_experiences", levelDetails)).Wait();
        }

        public static void GetJobXpMapping()
        {
            List<LevelDetail> levelDetails = new List<LevelDetail>();
            levelDetails.Add(new LevelDetail(1, 0));
            int baseValue = 0;
            int oldBaseValue = 0;

            for(int i = 2; i < 201; i++)
            {
                int result = baseValue + (baseValue - oldBaseValue) + 20;
                if (i == 1)
                {
                    result = 20;
                }

                oldBaseValue = baseValue;
                baseValue = result;

                Console.WriteLine("LVL {0} XP necessaire {1}", i, result);
                levelDetails.Add(new LevelDetail(i, result));
            }

            Task.Run(async () => await ConvertListToCollection<LevelDetail>("jobs_experiences", levelDetails)).Wait();
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
