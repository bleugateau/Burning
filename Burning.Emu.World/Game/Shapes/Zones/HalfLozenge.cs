using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class HalfLozenge : IZone
    {
        private uint _radius = 0;

        private uint _minRadius = 2;

        private uint _direction = 6;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        public HalfLozenge(uint minRadius, uint nRadius, Burning.DofusProtocol.Data.D2P.Map dataMapProvider)
        {
            this._radius = nRadius;
            this._minRadius = minRadius;
            this._dataMapProvider = dataMapProvider;
        }


        public List<uint> getCells(uint param1)
        {
            int i = 0;
            List<uint> aCells = new List<uint>();
            Burning.DofusProtocol.Data.D2P.MapPoint origin = new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1);
            int x = origin.X;
            int y = origin.Y;
            if (this._minRadius == 0)
            {
                aCells.Add(param1);
            }
            for (i = 1; i <= this._radius;)
            {
                switch ((DirectionsEnum)this._direction)
                {
                    case DirectionsEnum.DIRECTION_NORTH_WEST:
                        this.addCell(x + i, y + i, aCells);
                        this.addCell(x + i, y - i, aCells);
                        break;
                    case DirectionsEnum.DIRECTION_NORTH_EAST:
                        this.addCell(x - i, y - i, aCells);
                        this.addCell(x + i, y - i, aCells);
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH_EAST:
                        this.addCell(x - i, y + i, aCells);
                        this.addCell(x - i, y - i, aCells);
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH_WEST:
                        this.addCell(x - i, y + i, aCells);
                        this.addCell(x + i, y + i, aCells);
                        break;
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
