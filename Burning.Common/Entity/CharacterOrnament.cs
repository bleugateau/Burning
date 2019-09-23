using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class CharacterOrnament : IEntity
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public int OrnamentId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public CharacterOrnament() { }
    }
}
