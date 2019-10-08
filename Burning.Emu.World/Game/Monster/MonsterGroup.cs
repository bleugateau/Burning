using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.PathFinder;
using Burning.Emu.World.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Burning.Emu.World.Game.Monster
{
    public class MonsterGroup
    {
        public int Id { get; set; }

        public Map.Map Map { get; set; }

        public GameRolePlayGroupMonsterInformations RolePlayGroupMonsterInformations { get; set; }

        public List<Burning.DofusProtocol.Datacenter.Monster> Monsters { get; set; }

        private Timer MovementTimer { get; set; }

        private Random random = new Random();

        public MonsterGroup(Map.Map map)
        {
            this.Map = map;
            this.Id = (random.Next(1, 99999999) * (this.Map.Id / 2));

            this.Monsters = new List<DofusProtocol.Datacenter.Monster>();

            var monsterInSubarea = MonsterRepository.Instance.GetMonstersFromSubarea((uint)this.Map.MapData.SubAreaId);

            if (monsterInSubarea.Count == 0)
                return;

            int numberOfMonster = random.Next(1, 8 + 1);
            var groupStatic = new GroupMonsterStaticInformations();

            groupStatic.underlings = new List<MonsterInGroupInformations>();

            for (int m = 0; m < numberOfMonster; m++)
            {
                int monsterNum = random.Next(0, monsterInSubarea.Count - 1);
                if (m == 0)
                {
                    groupStatic.mainCreatureLightInfos = new MonsterInGroupLightInformations(monsterInSubarea[monsterNum].Id, monsterInSubarea[monsterNum].Grades[0].Grade, monsterInSubarea[monsterNum].Grades[0].Level);
                }
                else
                {
                    groupStatic.underlings.Add(new MonsterInGroupInformations(monsterInSubarea[monsterNum].Id, monsterInSubarea[monsterNum].Grades[0].Grade, monsterInSubarea[monsterNum].Grades[0].Level, Look.Parse(monsterInSubarea[monsterNum].Look).GetEntityLook()));
                }

                this.Monsters.Add(monsterInSubarea[monsterNum]);
            }


            this.RolePlayGroupMonsterInformations = new GameRolePlayGroupMonsterInformations(this.Id, new EntityDispositionInformations(MapManager.Instance.CheckWalkableCell(this.Map, random.Next(100, 342)), 4), Look.Parse(monsterInSubarea[0].Look).GetEntityLook(), groupStatic, 0, 255, false, false, false);

            Console.WriteLine("MONSTER GROUP {0} SPAWNED. ", this.Id);

            //movement
            this.StartMovementTimer();
        }

        private void StartMovementTimer()
        {
            this.MovementTimer = new System.Timers.Timer(7500);
            // Hook up the Elapsed event for the timer. 
            this.MovementTimer.Elapsed += MovementTimer_Elapsed;
            this.MovementTimer.AutoReset = true;
            this.MovementTimer.Enabled = true;
        }

        private void MovementTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var keyMovements = this.Map.Pathfinder.GetPath((short)this.RolePlayGroupMonsterInformations.disposition.cellId, (short)(this.RolePlayGroupMonsterInformations.disposition.cellId + 1)).Select(x => (uint)x.Id).ToList();

            foreach(var client in WorldManager.Instance.GetClientsOnMapId(this.Map.Id))
            {
                //update
                client.SendPacket(new GameMapMovementMessage(keyMovements, 2, this.Id));
            }

            this.RolePlayGroupMonsterInformations.disposition.cellId = (int)keyMovements[keyMovements.Count - 1];
        }
    }
}
