using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Burning.Emu.World.Game.PathFinder
{
    public class Cell
    {
        #region Declarations

        public bool Pair { get; private set; }
        public bool ChangeMap { get; private set; }
        public bool Walkable { get; private set; }
        public bool Los { get; private set; }
        public bool InOpenList { get; set; }
        public bool InClosedList { get; set; }
        public bool Start { get; set; }
        public bool End { get; set; }
        public byte[] Position { get; private set; }
        public Point Location { get; private set; }
        public int Id { get; private set; }
        public Cell Parent { get; set; }
        public uint F { get; set; }
        public uint G { get; set; }
        public uint H { get; set; }
        public int Orientation { get; private set; }

        #endregion

        #region Public method

        public Cell(bool changeMap, bool walkable, bool los, int column, int line, int id, Point location)
        {
            ChangeMap = changeMap;
            Walkable = walkable;
            Los = los;
            Id = id;
            Pair = line % 2 == 0;
            Location = location;
            GetBorder(column, line);
        }

        public void SetH(Cell endCell)
        {
            H = (uint)(10 * (Math.Abs(endCell.Location.X - Location.X) + Math.Abs(endCell.Location.X - Location.Y)));
        }
        public uint DistanceTo(Cell cell)
        {
            return (uint)Math.Sqrt((cell.Location.X - Location.X) * (cell.Location.X - Location.X) + (cell.Location.Y - Location.Y) * (cell.Location.Y - Location.Y));
        }
        public int DistanceToCell(Cell cell)
        {
            return (Math.Abs(Convert.ToInt32((this.Location.X - cell.Location.X))) + Math.Abs(Convert.ToInt32((this.Location.Y - cell.Location.Y))));
        }
        public uint ManhattanDistanceTo(Cell cell)
        {
            if (cell == null) return 255;
            return (uint)(Math.Abs(Location.X - cell.Location.X) + Math.Abs(Location.Y - cell.Location.Y));
        }

        public bool IsInRadius(Cell cell, int radius)
        {
            return ManhattanDistanceTo(cell) <= radius;
        }

        public bool IsInRadius(Cell cell, int minRadius, int radius)
        {
            uint dist = ManhattanDistanceTo(cell);
            return dist >= minRadius && dist <= radius;
        }

        public bool IsAdjacentTo(Cell cell, bool diagonal = true)
        {
            uint dist = diagonal ? DistanceTo(cell) : ManhattanDistanceTo(cell);

            return dist == 1;
        }
        public List<int> GetConnectedCells()
        {
            List<int> list = new List<int>();
            list.Add(PathingUtils.CoordToCellId(Location.X - 1, Location.Y));
            list.Add(PathingUtils.CoordToCellId(Location.X, Location.Y - 1));
            list.Add(PathingUtils.CoordToCellId(Location.X + 1, Location.Y));
            list.Add(PathingUtils.CoordToCellId(Location.X, Location.Y + 1));
            return list;
        }
        public int GetCellInDirection(DirectionsEnum direction, short step)
        {
            Point ThatCell;
            switch (direction)
            {
                case DirectionsEnum.DIRECTION_EAST:
                    {
                        ThatCell = new Point(Location.X + step, Location.Y + step);
                        break;
                    }
                case DirectionsEnum.DIRECTION_SOUTH_EAST:
                    {
                        ThatCell = new Point(Location.X + step, Location.Y);
                        break;
                    }
                case DirectionsEnum.DIRECTION_SOUTH:
                    {
                        ThatCell = new Point(Location.X + step, Location.Y - step);
                        break;
                    }
                case DirectionsEnum.DIRECTION_SOUTH_WEST:
                    {
                        ThatCell = new Point(Location.X, Location.Y - step);
                        break;
                    }
                case DirectionsEnum.DIRECTION_WEST:
                    {
                        ThatCell = new Point(Location.X - step, Location.Y - step);
                        break;
                    }
                case DirectionsEnum.DIRECTION_NORTH_WEST:
                    {
                        ThatCell = new Point(Location.X - step, Location.Y);
                        break;
                    }
                case DirectionsEnum.DIRECTION_NORTH:
                    {
                        ThatCell = new Point(Location.X - step, Location.Y + step);
                        break;
                    }
                case DirectionsEnum.DIRECTION_NORTH_EAST:
                    {
                        ThatCell = new Point(Location.X, Location.Y + step);
                        break;
                    }
                default:
                    throw new Exception("Unknown direction : " + direction);
            }
            return PathingUtils.CoordToCellId(ThatCell.X, ThatCell.Y);
        }
        public static bool IsInMap(int x, int y)
        {
            return x + y >= 0 && x - y >= 0 && x - y < 20 * 2 && x + y < 14 * 2;
        }

        public override string ToString()
        {
            return String.Format("Id : {0} Location : ({1} ; {2})", Id, Location.X, Location.Y);
        }

        #endregion

        #region Private method

        private void GetBorder(int column, int line)
        {
            Position = new byte[8];
            if (line == 0)
                Position[0] = 1;
            if (line == 1)
                Position[1] = 1;
            if (line == 39)
                Position[2] = 1;
            if (line == 38)
                Position[3] = 1;
            if (column == 0 && Pair)
                Position[4] = 1;
            if (column == 0 && !Pair)
                Position[5] = 1;
            if (column == 13 && !Pair)
                Position[6] = 1;
            if (column == 13 && Pair)
                Position[7] = 1;
        }

        #endregion
    }
}