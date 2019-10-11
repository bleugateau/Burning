using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class ZRectangle : IZone
    {

        public uint _radius = 0;

        private uint _radius2;

        private uint _minRadius = 2;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        public bool _diagonalFree = false;


        public ZRectangle(uint nMinRadius, uint nWidth, uint nHeight, Burning.DofusProtocol.Data.D2P.Map dataMapProvider)
        {
            this._radius = nWidth;
            this._radius2 = nHeight != 0 ? nHeight : nWidth;
            this._minRadius = nMinRadius;
            this._dataMapProvider = dataMapProvider;
        }

        public List<uint> getCells(uint param1)
        {
            int i = 0;
            int j = 0;
            List<uint> aCells = new List<uint>();
            Burning.DofusProtocol.Data.D2P.MapPoint origin = new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1);
            int x = origin.X;
            int y = origin.Y;
            if (this._radius == 0 || this._radius2 == 0)
            {
                if (this._minRadius == 0 && !this._diagonalFree)
                {
                    aCells.Add(param1);
                }
                return aCells;
            }
            for (i = x - (int)this._radius; i <= x + this._radius;)
            {
                for (j = y - (int)this._radius2; j <= y + this._radius2;)
                {
                    if (this._minRadius == 0 || Math.Abs(x - i) + Math.Abs(y - j) >= this._minRadius)
                    {
                        if (!this._diagonalFree || Math.Abs(x - i) != Math.Abs(y - j))
                        {
                            if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(i, j))
                            {
                                this.addCell(i, j, aCells);
                            }
                        }
                    }
                    j++;
                }
                i++;
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
