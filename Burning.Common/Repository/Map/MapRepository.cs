using Burning.Common.Managers.Singleton;
using Burning.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Burning.DofusProtocol.Data.D2P.Utils;
using FlatyBot.Common.IO;
using Burning.DofusProtocol.Data.D2P;

namespace Burning.Common.Repository
{
    public class MapRepository : SingletonManager<MapRepository>, InterfaceTest<Map>
    {
        public RepositoryAccessor Accessor { get; set; }
        public List<Map> List { get; set; }
        public string TableName { get; set; }

        public void Initialize(string tableName)
        {
            this.TableName = tableName;
            this.Accessor = new RepositoryAccessor(this.TableName);
            this.List = new List<Map>();

            D2pManager.Setup("./" + this.TableName + "/"); //initialize

            MapPositionRepository.Instance.Initialize("MapPositions");
            NpcSpawnRepository.Instance.Initialize("npcs_spawns"); //load npcs
        }

        public Map GetMap(int mapId)
        {
            var map = MapRepository.Instance.List.Find(x => x.Id == mapId);

            if (map == null)
            {
                map = D2pManager.FromId(mapId);
                MapRepository.Instance.List.Add(map);
            }

            return map;
        }

        public bool CheckIfNextMapIsValid(int actualMapId, int newMapId, int cellId)
        {
            var destinationOrientation = GetMapNeighbourTransitionEnumFromCell(cellId);
            var position = MapPositionRepository.Instance.List.Find(x => x.Id == actualMapId);

            Point nextMapPoint = new Point(position.PosX, position.PosY);

            switch(destinationOrientation)
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

        public int CheckWalkableCell(int mapId, int cellId)
        {
            var map = this.GetMap(mapId);

            var cellWalkable = map.Cells.ToList().FindAll(x => x.Walkable && x.isObstacle() != true);
            var cellData = map.Cells.ToList().FirstOrDefault(x => x.Id == cellId);

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

        public uint DistanceBetweenCell(Point cell1, Point cell2) {
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
            if(isLeftCol(cellId))
            {
                return (cellId + 13);
            }
            else if(isRightCol(cellId))
            {
                return (cellId - 13);
            }
            else if(isTopRow(cellId))
            {
                return (cellId + 532);
            }
            else if(isBottomRow(cellId))
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
