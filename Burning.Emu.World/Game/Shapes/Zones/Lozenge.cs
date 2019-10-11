using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class Lozenge : IZone
    {
        private uint _radius = 0;

        private uint _minRadius = 2;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        public Lozenge(uint nMinRadius, uint nRadius,Burning.DofusProtocol.Data.D2P.Map dataMapProvider)
        {
            this._radius = nRadius;
            this._minRadius = nMinRadius;
            this._dataMapProvider = dataMapProvider;
        }

        public List<uint> getCells(uint param1)
        {
            int i = 0;
            int j = 0;
            int radiusStep = 0;
            int xResult = 0;
            int yResult = 0;
            List<uint> aCells = new List<uint>();
            Burning.DofusProtocol.Data.D2P.MapPoint origin = new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1);
            int x = origin.X;
            int y = origin.Y;
            if (this._radius == 0)
            {
                if (this._minRadius == 0)
                {
                    aCells.Add(param1);
                }
                return aCells;
            }
            for (radiusStep = (int)this._radius; radiusStep >= this._minRadius;)
            {
                for (i = -radiusStep; i <= radiusStep; i++)
                {
                    for (j = -radiusStep; j <= radiusStep;)
                    {
                        if (Math.Abs(i) + Math.Abs(j) == radiusStep)
                        {
                            xResult = x + i;
                            yResult = y + j;
                            if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(xResult, yResult))
                            {
                                this.addCell(xResult, yResult, aCells);
                            }
                        }
                        j++;
                    }
                }
                radiusStep--;
            }
            return aCells;
        }

        private void addCell(int x, int y, List<uint> cellMap)
        {
            var cell = this._dataMapProvider.Cells.ToList().Find(c => c.X == x && c.Y == y);
            if (cell == null)
                return;

            cellMap.Add(cell.Id);
        }
    }
}
