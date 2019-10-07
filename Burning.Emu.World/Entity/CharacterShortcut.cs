using Burning.Common.Entity;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Repository;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class CharacterShortcut : AbstractEntity
    {
        public int CharacterId { get; set; }

        public ShortcutBarEnum BarType { get; set; }

        public List<Shortcut> ShortcutObjects { get; set; }

        [BsonIgnore]
        public Character Character
        {
            get
            {
                return CharacterRepository.Instance.GetCharacterById(this.CharacterId);
            }
        }
    }
}
