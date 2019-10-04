using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Fighters
{
    public abstract class Fighter
    {
        public int Id { get; set; }

        public int TimelineOrder { get; set; }

        public int Initiative { get; set; }

        public int Life { get; set; }

        public int LifeBase { get; set; }

        public int AP { get; set; }

        public int PM { get; set; }

        public int CellId { get; set; }

        public Fighter()
        {

        }

    }
}
