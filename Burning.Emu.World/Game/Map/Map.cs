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

namespace Burning.Emu.World.Game.Map
{
    public class Map
    {
        public int Id { get; set; }

        public List<NpcSpawn> NpcSpawnList { get; set; }

        public List<InteractiveElement> InteractiveElementList { get; set; }

        public List<StatedElement> StatedElementList { get; set; }

        public List<MonsterGroup> MonstersGroups { get; set; }

        public Burning.DofusProtocol.Data.D2P.Map MapData { get; set; }

        public FightStartingPositions FightStartingPosition { get; private set; }

        private int MonsterGroupsLimit { get; set; }

        public Map(int mapId, Burning.DofusProtocol.Data.D2P.Map mapData, int monsterGroupsLimit = 3)
        {
            this.Id = mapId;
            this.MapData = mapData;
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
            Random random = new Random();

            List<MonsterGroup> groupMonsters = new List<MonsterGroup>();
            var monsterInSubarea = MonsterRepository.Instance.GetMonstersFromSubarea((uint)this.MapData.SubAreaId);

            int actualMonsterGroupSize = this.MonstersGroups != null ? this.MonstersGroups.Count : 0;

            if (monsterInSubarea.Count == 0)
                return new List<MonsterGroup>();

            for(int i = actualMonsterGroupSize; i < this.MonsterGroupsLimit; i++)
            {
                int numberOfMonster = random.Next(1, 8 + 1);
                var groupStatic = new GroupMonsterStaticInformations();
                
                groupStatic.underlings = new List<MonsterInGroupInformations>();

                for (int m = 0; m < numberOfMonster; m++)
                {
                    int monsterNum = random.Next(1, monsterInSubarea.Count);
                    if (m == 0)
                    {
                        groupStatic.mainCreatureLightInfos = new MonsterInGroupLightInformations(monsterInSubarea[monsterNum].Id, monsterInSubarea[monsterNum].Grades[0].Grade, monsterInSubarea[monsterNum].Grades[0].Level);
                    }
                    else
                    {
                        groupStatic.underlings.Add(new MonsterInGroupInformations(monsterInSubarea[monsterNum].Id, monsterInSubarea[monsterNum].Grades[0].Grade, monsterInSubarea[monsterNum].Grades[0].Level, Look.Parse(monsterInSubarea[monsterNum].Look).GetEntityLook()));
                    }
                }

                var group = new GameRolePlayGroupMonsterInformations((random.Next(1, 99999999) * (this.Id / 2)), new EntityDispositionInformations(MapManager.Instance.CheckWalkableCell(this, random.Next(100, 342)), 4), Look.Parse(monsterInSubarea[0].Look).GetEntityLook(), groupStatic, 0, 255, false, false, false);
                groupMonsters.Add(new MonsterGroup((int)group.contextualId, this, group));
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
