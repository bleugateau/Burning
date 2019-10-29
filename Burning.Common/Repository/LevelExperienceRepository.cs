using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burning.Common.Repository
{
    public class LevelExperienceRepository : SingletonManager<LevelExperienceRepository>, IRepository<LevelExperience>
    {
        public IMongoCollection<LevelExperience> Collection { get; set; }

        public List<LevelExperience> CharacterLevels { get; set; }
        public List<LevelExperience> GuildLevels { get; set; }
        public List<LevelExperience> JobLevels { get; set; }
        public List<LevelExperience> MountLevels { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<LevelExperience>("characters_experiences");
            Task.Run(() => this.FillListFromCollection()).Wait();

            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<LevelExperience>("guilds_experiences");
            Task.Run(() => this.FillListFromCollection()).Wait();

            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<LevelExperience>("jobs_experiences");
            Task.Run(() => this.FillListFromCollection()).Wait();

            this.Collection = DatabaseManager.Instance.DataCenter.GetCollection<LevelExperience>("mounts_experiences");
            Task.Run(() => this.FillListFromCollection()).Wait();
        }

        private Task FillListFromCollection()
        {
            switch(this.Collection.CollectionNamespace.CollectionName)
            {

                case "characters_experiences":
                    this.CharacterLevels = this.Collection.Find(_ => true).ToList();
                    break;
                case "guilds_experiences":
                    this.GuildLevels = this.Collection.Find(_ => true).ToList();
                    break;
                case "jobs_experiences":
                    this.JobLevels = this.Collection.Find(_ => true).ToList();
                    break;
                case "mounts_experiences":
                    this.MountLevels = this.Collection.Find(_ => true).ToList();
                    break;

                default:
                    throw new Exception("Collection " + this.Collection.CollectionNamespace.CollectionName + " namespace is not implemented");
            }

            Console.WriteLine("{0} is loaded.", this.Collection.CollectionNamespace.CollectionName);

            return Task.CompletedTask;
        }

        public void Insert(LevelExperience entity)
        {
            throw new NotImplementedException();
        }

        public void Update(LevelExperience entity)
        {
            throw new NotImplementedException();
        }
    }
}
