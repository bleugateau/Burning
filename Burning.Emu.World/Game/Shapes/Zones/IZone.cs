using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public interface IZone
    {
        List<uint> getCells(uint param1);
    }
}
