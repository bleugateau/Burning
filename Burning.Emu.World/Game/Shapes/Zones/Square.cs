using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class Square : ZRectangle
    {
        public Square(uint nMinRadius, uint nRadius, Burning.DofusProtocol.Data.D2P.Map dataMapProvider) : base(nMinRadius, nRadius, nRadius, dataMapProvider)
        {

        }

        public int getsurface()
        {
            return (int)Math.Pow(this._radius * 2 + 1, 2);
        }
    }
}
