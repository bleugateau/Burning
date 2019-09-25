using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class CharacterOrnament : AbstractEntity
    {
        public int CharacterId { get; set; }

        public int OrnamentId { get; set; }

        public CharacterOrnament() { }
    }
}
