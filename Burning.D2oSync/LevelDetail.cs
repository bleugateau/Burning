using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.D2oSync
{
    public class LevelDetail
    {
        [BsonId]
        private int Id;
        public int Level;
        public double Experience;

        public LevelDetail(int level, double exp)
        {
            Id = level;
            Level = level;
            Experience = exp;
        }
    }
}
