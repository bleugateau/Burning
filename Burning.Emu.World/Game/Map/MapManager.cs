using Burning.Common.Entity;
using Burning.Common.Enums;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.Emu.World.Game.World;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Data.D2P;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Burning.Emu.World.Repository;

namespace Burning.Emu.World.Game.Map
{
    public class MapManager : SingletonManager<MapManager>
    {
        public D2pManager D2PManager { get; set; }

        private List<Map> maps { get; set;}

        public MapManager (){}

        public void Initialize(string directory)
        {
            D2pManager.Setup("./" + directory + "/"); //initialize

            this.maps = new List<Map>();

            MapPositionRepository.Instance.Initialize("MapPositions"); //load map position
            NpcSpawnRepository.Instance.Initialize("npcs_spawns"); //load npcs

            Console.WriteLine("Map lazy loading from d2p...");
        }

        public Map GetMap(int mapId)
        {
            var map = this.maps.Find(x => x.Id == mapId);

            if (map == null)
            {
                var mapData = D2pManager.FromId(mapId);
                map = new Map(mapData.Id, mapData);
                this.maps.Add(map);
            }

            return map;
        }

        public bool CheckIfNextMapIsValid(int actualMapId, int newMapId, int cellId)
        {
            var destinationOrientation = GetMapNeighbourTransitionEnumFromCell(cellId);
            var position = MapPositionRepository.Instance.List.Find(x => x.Id == actualMapId);

            Point nextMapPoint = new Point(position.PosX, position.PosY);

            switch (destinationOrientation)
            {
                case MapNeighbourTransitionEnum.TOP:
                    nextMapPoint.Y = nextMapPoint.Y - 1;
                    break;
                case MapNeighbourTransitionEnum.LEFT:
                    nextMapPoint.X = nextMapPoint.X - 1;
                    break;
                case MapNeighbourTransitionEnum.BOTTOM:
                    nextMapPoint.Y = nextMapPoint.Y + 1;
                    break;
                case MapNeighbourTransitionEnum.RIGHT:
                    nextMapPoint.X = nextMapPoint.X + 1;
                    break;
            }

            var maps = MapPositionRepository.Instance.List.FindAll(x => x.PosX == nextMapPoint.X && x.PosY == nextMapPoint.Y && x.Id == newMapId);
            if (maps.Count != 0)
                return true;


            return false;
        }

        public int CheckWalkableCell(Map map, int cellId)
        {
            var cellWalkable = map.MapData.Cells.ToList().FindAll(x => x.Walkable && x.isObstacle() != true);
            var cellData = map.MapData.Cells.ToList().FirstOrDefault(x => x.Id == cellId);

            if (map != null)
            {
                if (cellWalkable.Find(x => x.Id == (uint)cellId) == null)
                {
                    return (int)cellWalkable.OrderBy(x => this.DistanceBetweenCell(new Point(cellData.X, cellData.Y), new Point(x.X, x.Y))).FirstOrDefault(x => x.Id == x.Id).Id;

                }
                return cellId;
            }

            return 0;
        }

        public uint DistanceBetweenCell(Point cell1, Point cell2)
        {
            return (uint)System.Math.Sqrt((double)((cell1.X - cell2.X) * (cell1.X - cell2.X) + (cell1.Y - cell2.Y) * (cell1.Y - cell2.Y)));
        }

        public int GetCellIdFromKeyMovement(int keyMovement)
        {
            return (int)(keyMovement & 4095);
        }

        public MapNeighbourTransitionEnum GetMapNeighbourTransitionEnumFromCell(int cellId)
        {
            if (isLeftCol(cellId))
            {
                return MapNeighbourTransitionEnum.LEFT;
            }
            else if (isRightCol(cellId))
            {
                return MapNeighbourTransitionEnum.RIGHT;
            }
            else if (isTopRow(cellId))
            {
                return MapNeighbourTransitionEnum.TOP;
            }

            return MapNeighbourTransitionEnum.BOTTOM;
        }

        //check dans le futur de recup la cell la plus proch si elle est non marchable
        public int GetOppositeCellFromNeight(int cellId)
        {
            if (isLeftCol(cellId))
            {
                return (cellId + 13);
            }
            else if (isRightCol(cellId))
            {
                return (cellId - 13);
            }
            else if (isTopRow(cellId))
            {
                return (cellId + 532);
            }
            else if (isBottomRow(cellId))
            {
                return (cellId - 532);
            }
            return 0;
        }

        //CellUtil
        private bool isLeftCol(int cellId)
        {
            return cellId % 14 == 0;
        }

        private bool isRightCol(int cellId)
        {
            return isLeftCol(cellId + 1);
        }

        private bool isTopRow(int cellId)
        {
            return cellId < 28;
        }

        private bool isBottomRow(int cellId)
        {
            return cellId > 531;
        }
    }
}
