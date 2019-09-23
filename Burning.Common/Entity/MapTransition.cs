using Burning.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class MapTransition : IEntity
    {
        public int Id { get; set; }

        public int mapIdRequested { get; set; }

        public int mapIdReplaced { get; set; }

        public MapNeighbourTransitionEnum  fromNeighbour { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public MapTransition() { }
    }
}
