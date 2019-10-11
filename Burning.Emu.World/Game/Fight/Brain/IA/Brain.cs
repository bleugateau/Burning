using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Burning.Emu.World.Game.Fight.Brain.IA
{
    public abstract class Brain
    {
        public Fight Fight { get; set; }

        public bool IsInitiallized { get; set; }
    }
}
