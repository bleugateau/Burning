using Burning.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class MapInteractiveElement : AbstractEntity
    {
        public int MapId { get; set; }

        public int ElementId { get; set; }

        public int TypeId { get; set; }

        public int SkillId { get; set; }
    }
}
