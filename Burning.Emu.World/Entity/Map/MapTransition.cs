using Burning.Common.Entity;
using Burning.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class MapTransition : AbstractEntity
    {

        public int MapIdRequested { get; set; }

        public int MapIdReplaced { get; set; }

        public MapNeighbourTransitionEnum  FromNeighbour { get; set; }


        public MapTransition() { }
    }
}
