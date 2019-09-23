using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class NpcSpawn : IEntity
    {
        public int Id { get; set; }

        public int NpcId { get; set; }

        public string EntityLook { get; set; }

        public bool Gender { get; set; }

        public int MapId { get; set; }

        public int CellId { get; set; }

        public int Orientation { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }
    }
}
