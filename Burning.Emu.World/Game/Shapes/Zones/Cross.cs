using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes.Zones
{
    public class Cross : IZone
    {
        private uint radius = 0;

        private uint minRadius = 0;

        private Burning.DofusProtocol.Data.D2P.Map _dataMapProvider;

        private uint _direction;

        public bool _diagonal = false;

        public bool _allDirections = false;

        public List<DirectionsEnum> disabledDirection;

        public bool onlyPerpendicular = false;

        public Cross(uint nMinRadius, uint nMaxRadius, Burning.DofusProtocol.Data.D2P.Map map)
        {
            this.disabledDirection = new List<DirectionsEnum>();
            this.minRadius = nMinRadius;
            this.radius = nMaxRadius;
            this._dataMapProvider = map;
        }

        public List<uint> getCells(uint param1)
        {
            List<uint> aCells = new List<uint>();
            if (this.minRadius == 0)
            {
                aCells.Add(param1);
            }
            if (this.onlyPerpendicular)
            {
                switch ((DirectionsEnum)this._direction)
                {
                    case DirectionsEnum.DIRECTION_SOUTH_EAST: //DOWN_RIGHT
                    case DirectionsEnum.DIRECTION_NORTH_WEST:
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_SOUTH_EAST);
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_NORTH_WEST);
                        break;
                    case DirectionsEnum.DIRECTION_NORTH_EAST:
                    case DirectionsEnum.DIRECTION_SOUTH_WEST:
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_NORTH_EAST);
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_SOUTH_WEST);
                        break;
                    case DirectionsEnum.DIRECTION_SOUTH:
                    case DirectionsEnum.DIRECTION_NORTH:
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_SOUTH);
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_NORTH);
                        break;
                    case DirectionsEnum.DIRECTION_EAST:
                    case DirectionsEnum.DIRECTION_WEST:
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_EAST);
                        this.disabledDirection.Add(DirectionsEnum.DIRECTION_WEST);
                        break;
                }
            }
            Burning.DofusProtocol.Data.D2P.MapPoint origin = new Burning.DofusProtocol.Data.D2P.MapPoint((int)param1);
            int x = origin.X;
            int y = origin.Y;
            for (uint r = this.radius; r > 0;)
            {
                if (r >= this.minRadius)
                {
                    if (!this._diagonal)
                    {
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), y) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_SOUTH_EAST))
                        {
                            this.addCell((int)(x + r), y, aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), y) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_NORTH_WEST))
                        {
                            this.addCell((int)(x - r), y, aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(x, (int)(y + r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_NORTH_EAST))
                        {
                            this.addCell(x, (int)(y + r), aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap(x, (int)(y - r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_SOUTH_WEST))
                        {
                            this.addCell(x, (int)(y - r), aCells);
                        }
                    }
                    if (this._diagonal || this._allDirections)
                    {
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), (int)(y - r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_SOUTH))
                        {
                            this.addCell((int)(x + r), (int)(y - r), aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), (int)(y + r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_NORTH))
                        {
                            this.addCell((int)(x - r), (int)(y + r), aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x + r), (int)(y + r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_EAST))
                        {
                            this.addCell((int)(x + r), (int)(y + r), aCells);
                        }
                        if (Burning.DofusProtocol.Data.D2P.MapPoint.isInMap((int)(x - r), (int)(y - r)) && !this.disabledDirection.Contains(DirectionsEnum.DIRECTION_WEST))
                        {
                            this.addCell((int)(x - r), (int)(y - r), aCells);
                        }
                    }
                }
                r--;
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
