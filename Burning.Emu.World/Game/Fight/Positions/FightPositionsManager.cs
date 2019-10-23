using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Game.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Positions
{
    public class FightPositionsManager : SingletonManager<FightPositionsManager>
    {

        public List<FightStartingPositions> FightStartingPositions { get; set; }

        private bool IsInitialized = false;

        private Random Random;

        public void Initialize()
        {
            this.FightStartingPositions = new List<FightStartingPositions>();
            this.Random = new Random();

            foreach (var fightPos in Directory.GetFiles("fight_schemas/"))
            {
                StreamReader reader = new StreamReader(fightPos);
                string line = "";
                bool challengersPos = false;
                bool defendersPos = false;
                int mapId = 0;
                var fightposition = new FightStartingPositions();
                List<uint> posChallengers = new List<uint>();
                List<uint> posDefenders = new List<uint>();

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("MAPID"))
                        mapId = int.Parse(line.Replace("MAPID=", ""));

                    if (line.Contains("[CHALLENGERS]"))
                        challengersPos = true;
                    else if (line.Contains("[DEFENDERS]"))
                    {
                        challengersPos = false;
                        defendersPos = true;
                    }
                    else if (challengersPos && line != "")
                    {
                        posChallengers.Add(uint.Parse(line));
                    }

                    else if (defendersPos && line != "")
                    {
                        posDefenders.Add(uint.Parse(line));
                    }
                }

                fightposition.positionsForChallengers = posChallengers;
                fightposition.positionsForDefenders = posDefenders;


                if (mapId != 0 && fightposition.positionsForChallengers.Count > 0 && fightposition.positionsForDefenders.Count > 0)
                    this.FightStartingPositions.Add(fightposition);

                reader.Close();
                reader.Dispose();
            }

            this.IsInitialized = true;
            Console.WriteLine("{0} schemas for fight positions loaded.", this.FightStartingPositions.Count);
        }

        public FightStartingPositions BuildFromSchema(Map.Map map)
        {
            if (!this.IsInitialized)
                this.Initialize();

            var schema = this.FightStartingPositions[this.Random.Next(1, this.FightStartingPositions.Count)];
            var finalFightStartingPos = new FightStartingPositions();

            try
            {
                List<uint> mixedCell = new List<uint>();
                List<uint> cellWalkableForChallengers = new List<uint>();

                foreach (var cell in schema.positionsForChallengers)
                {
                    uint walkableCell = this.GetWalkableCell(map, cell, cellWalkableForChallengers);

                    if (walkableCell != 0)
                    {
                        cellWalkableForChallengers.Add(walkableCell);
                        mixedCell.Add(walkableCell);
                    }
                        
                }

                List<uint> cellWalkableForDefenders = new List<uint>();
                foreach (var cell in schema.positionsForDefenders)
                {
                    uint walkableCell = this.GetWalkableCell(map, cell, mixedCell);
                    if (walkableCell != 0 && !mixedCell.Contains(walkableCell))
                    {
                        cellWalkableForDefenders.Add(walkableCell);
                        mixedCell.Add(walkableCell);
                    }
                }

                finalFightStartingPos.positionsForChallengers = cellWalkableForChallengers;
                finalFightStartingPos.positionsForDefenders = cellWalkableForDefenders;

                if ((finalFightStartingPos.positionsForChallengers.Count != schema.positionsForChallengers.Count) || (finalFightStartingPos.positionsForDefenders.Count != schema.positionsForDefenders.Count))
                    this.BuildNewSchema(map);

            }
            catch(Exception ex)
            {
                return new FightStartingPositions();
            }


            return finalFightStartingPos;
        }

        private FightStartingPositions BuildNewSchema(Map.Map map)
        {

            Console.WriteLine("Build new fight schema");

            var finalFightStartingPos = new FightStartingPositions();
            var cellWalkable = map.MapData.Cells.ToList().FindAll(x => x.Walkable && x.isObstacle() != true).Select(x => (uint)x.Id).ToList();

            if (cellWalkable.Count < 25)
                return new FightStartingPositions();

            List<uint> cellWalkableForChallengers = new List<uint>();
            for (int i = 0; i < 12; i++) //build challengers
            {
                cellWalkableForChallengers.Add(cellWalkable[0]);
                cellWalkable.Remove(cellWalkable[0]);
            }

            List<uint> cellWalkableForDefenders = new List<uint>();
            for (int i = 0; i < 12; i++) //build defenders
            {
                cellWalkableForDefenders.Add(cellWalkable[0]);
                cellWalkable.Remove(cellWalkable[0]);
            }

            finalFightStartingPos.positionsForChallengers = cellWalkableForChallengers;
            finalFightStartingPos.positionsForDefenders = cellWalkableForDefenders;

            return finalFightStartingPos;
        }

        private uint GetWalkableCell(Map.Map map, uint cellId, List<uint> cellDestination)
        {
            var cellWalkable = map.MapData.Cells.ToList().FindAll(x => x.Walkable && x.isObstacle() != true && !x.NonWalkableDuringFight);
            var cellData = map.MapData.Cells.ToList().FirstOrDefault(x => x.Id == cellId);

            if (map != null)
            {
                if (cellWalkable.Find(x => x.Id == (uint)cellId) == null)
                {
                    var newCell = cellWalkable.OrderBy(x => MapManager.Instance.DistanceBetweenCell(new Point(cellData.X, cellData.Y), new Point(x.X, x.Y))).FirstOrDefault(x => !cellDestination.Contains(x.Id));
                    return newCell != null ? newCell.Id : 0;

                }
                return cellId;
            }

            return 0;
        }
    }
}
