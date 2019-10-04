using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Burning.Common.Entity;
using Burning.Common.Enums;
using Burning.Common.Network;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Game.Monster;
using Burning.Emu.World.Game.Fight.Positions;
using Burning.Emu.World.Game.PathFinder;

namespace Burning.Emu.World.Game.Map
{
    public class Map
    {
        public int Id { get; set; }

        public List<NpcSpawn> NpcSpawnList { get; set; }

        public List<InteractiveElement> InteractiveElementList { get; set; }

        public List<StatedElement> StatedElementList { get; set; }

        public List<MonsterGroup> MonstersGroups { get; set; }

        public Pathfinder Pathfinder { get; set; }

        public Burning.DofusProtocol.Data.D2P.Map MapData { get; set; }

        public FightStartingPositions FightStartingPosition { get; private set; }

        private int MonsterGroupsLimit { get; set; }

        public Map(int mapId, Burning.DofusProtocol.Data.D2P.Map mapData, int monsterGroupsLimit = 3)
        {
            this.Id = mapId;
            this.MapData = mapData;
            this.Pathfinder = new Pathfinder(new int[] { });
            this.Pathfinder.SetMap(this.MapData, true);
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(mapId);
            this.MonsterGroupsLimit = monsterGroupsLimit;
            this.MonstersGroups = FillMonstersGroups();
            this.FightStartingPosition = FightPositionsManager.Instance.BuildFromSchema(this);
            //startfightposition a faire

            this.InteractiveElementList = new List<InteractiveElement>(); //a fill avec la db
            this.StatedElementList = new List<StatedElement>(); //a fill avec la db
        }

        public List<MonsterGroup> FillMonstersGroups()
        {
            List<MonsterGroup> groupMonsters = new List<MonsterGroup>();
            int actualMonsterGroupSize = this.MonstersGroups != null ? this.MonstersGroups.Count : 0;

            for(int i = actualMonsterGroupSize; i < this.MonsterGroupsLimit; i++)
            {

                var group = new MonsterGroup(this);
                if(group.Monsters.Count != 0)
                    groupMonsters.Add(group);
            }

            return groupMonsters;
        }

        public void ReloadNpc()
        {
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(this.Id, false);
            Console.WriteLine("Npc from MapId {0} reloaded.", this.Id);
        }

        public void ReloadMobs()
        {
            Console.WriteLine("Mobs from MapId {0} reloaded.", this.Id);
        }
    }
}
