using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class Cone : IZone
    {
        private uint _radius = 0;

        private uint _minRadius = 0;

        private uint _nDirection = 1;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        public Cone(uint nMinRadius,uint nRadius, Burning.DofusProtocol.Data.D2P.Map dataMapProvider)
        {
            this._radius = nRadius;
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
            if (this._radius == 0)
            {
                if (this._minRadius == 0)
                {
                    aCells.Add(param1);
                }
                return aCells;
            }
            int inc = 1;
            uint step = 0;
            switch ((DirectionsEnum)this._nDirection)
            {
                case DirectionsEnum.DIRECTION_NORTH_WEST:
                    for (i = x; i >= x - this._radius; i--)
                    {
                        for (j = (int)-step; j <= step;)
                        {
                            if (this._minRadius == 0 || Math.Abs(x - i) + Math.Abs(j) >= this._minRadius)
                            {
                                if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(i, j + y))
                                {
                                    this.addCell(i, j + y, aCells);
                                }
                            }
                            j++;
                        }
                        step = step + (uint)inc;
                    }
                    break;
                case DirectionsEnum.DIRECTION_SOUTH_WEST:
                    for (j = y; j >= y - this._radius; j--)
                    {
                        for (i = (int)-step; i <= step;)
                        {
                            if (this._minRadius == 0 || Math.Abs(i) + Math.Abs(y - j) >= this._minRadius)
                            {
                                if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(i + x, j))
                                {
                                    this.addCell(i + x, j, aCells);
                                }
                            }
                            i++;
                        }
                        step = step + (uint)inc;
                    }
                    break;
                case DirectionsEnum.DIRECTION_SOUTH_EAST:
                    for (i = x; i <= x + this._radius; i++)
                    {
                        for (j = (int)-step; j <= step;)
                        {
                            if (this._minRadius == 0 || Math.Abs(x - i) + Math.Abs(j) >= this._minRadius)
                            {
                                if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(i, j + y))
                                {
                                    this.addCell(i, j + y, aCells);
                                }
                            }
                            j++;
                        }
                        step = step + (uint)inc;
                    }
                    break;
                case DirectionsEnum.DIRECTION_NORTH_EAST:
                    for (j = y; j <= y + this._radius; j++)
                    {
                        for (i = (int)-step; i <= step;)
                        {
                            if (this._minRadius == 0 || Math.Abs(i) + Math.Abs(y - j) >= this._minRadius)
                            {
                                if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(i + x, j))
                                {
                                    this.addCell(i + x, j, aCells);
                                }
                            }
                            i++;
                        }
                        step = step + (uint)inc;
                    }
                    break;
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
