using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class NpcSpawn : AbstractEntity
    {
        public int NpcId { get; set; }
        
        [BsonIgnore]
        public string EntityLook { get; set; }

        [BsonIgnore]
        public bool Gender { get; set; }

        public int MapId { get; set; }

        public int CellId { get; set; }

        public int Orientation { get; set; }
    }
}
