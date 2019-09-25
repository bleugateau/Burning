using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class CharacterTitle : AbstractEntity
    {
        public int CharacterId { get; set; }

        public int TitleId { get; set; }

        public CharacterTitle() { }
    }
}
