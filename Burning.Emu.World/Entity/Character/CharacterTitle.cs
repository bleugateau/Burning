using Burning.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class CharacterTitle : AbstractEntity
    {
        public int CharacterId { get; set; }

        public int TitleId { get; set; }

        public CharacterTitle() { }
    }
}
