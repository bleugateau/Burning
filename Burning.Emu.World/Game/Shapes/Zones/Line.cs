using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class Line : IZone
    {
        private uint _radius = 0;

        public uint _minRadius = 0;

        public uint _nDirection = 1;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        public bool _fromCaster;

        public bool _stopAtTarget;

        public uint _casterCellId;

        public Line(uint nRadius, Burning.DofusProtocol.Data.D2P.Map dataMapProvider)
        {
            this._radius = nRadius;
            this._dataMapProvider = dataMapProvider;
        }

        public List<uint> getCells(uint param1 = 0)
        {
            bool added = false;
            uint distance = 0;
            List<uint> aCells = new List<uint>();

            Burning.DofusProtocol.Data.D2P.MapPoint origin = !this._fromCaster ? new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1) : new Burning.DofusProtocol.Data.D2P.MapPoint((int)this._casterCellId);
            int x = origin.X;
            int y = origin.Y;
            uint length = !this._fromCaster ? this._radius : (this._radius + this._minRadius - 1);
            if (this._fromCaster && this._stopAtTarget)
            {
                var loc1 = new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1);
                distance = (uint)origin.DistanceToCell(loc1);
                length = distance < length ? distance : length;
            }

            for (uint r = this._minRadius; r <= length;)
            {
                switch ((DirectionsEnum)this._nDirection)
                {
                    case DirectionsEnum.DIRECTION_WEST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), (int)(y - r)))
                        {
                            added = this.addCell((int)(x - r), (int)(y - r), aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_NORTH:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), (int)(y + r)))
                        {
                            added = this.addCell((int)(x - r), (int)(y + r), aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_EAST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), (int)(y + r)))
                        {
                            added = this.addCell((int)(x + r), (int)(y + r), aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), (int)(y - r)))
                        {
                            added = this.addCell((int)(x + r), (int)(y - r), aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_NORTH_WEST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), y))
                        {
                            added = this.addCell((int)(x - r), y, aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH_WEST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(x, (int)(y - r)))
                        {
                            added = this.addCell(x, (int)(y - r), aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH_EAST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), y))
                        {
                            added = this.addCell((int)(x + r), y, aCells);
                        }
                        break;
                    case DirectionsEnum.DIRECTION_NORTH_EAST:
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(x, (int)(y + r)))
                        {
                            added = this.addCell(x, (int)(y + r), aCells);
                        }
                        break;
                }
                r++;
            }
            return aCells;
        }

        private bool addCell(int x, int y, List<uint> cellMap)
        {
            var cell = this._dataMapProvider.Cells.ToList().Find(c => c.X == x && c.Y == y);
            if (cell == null)
                return false;

            cellMap.Add(cell.Id);

            return true;
        }
    }
}
