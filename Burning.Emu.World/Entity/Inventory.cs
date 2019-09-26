using Burning.Common.Entity;
using Burning.DofusProtocol.Network.Types;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class Inventory : AbstractEntity
    {
        public int CharacterId { get; set; }

        public List<ObjectItem> ObjectItems { get; set; }

        [BsonIgnore]
        public List<ObjectItem> EquippedObjects { get; set; }

        [BsonIgnore]
        public int Pods { get; set; }

    }
}
