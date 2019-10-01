using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
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

        private Pathfinder Pathfinder { get; set; }
        private Timer MovementTimer { get; set; }

        public MonsterGroup(int id, Map.Map map, GameRolePlayGroupMonsterInformations gameRolePlayGroupMonsterInformations)
        {
            this.Id = id;
            this.Map = map;
            this.Pathfinder = new Pathfinder(new int[] { });
            this.Pathfinder.SetMap(this.Map.MapData, true);

            this.RolePlayGroupMonsterInformations = gameRolePlayGroupMonsterInformations;

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
            var keyMovements = this.Pathfinder.GetPath((short)this.RolePlayGroupMonsterInformations.disposition.cellId, (short)(this.RolePlayGroupMonsterInformations.disposition.cellId + 1)).Select(x => (uint)x.Id).ToList();

            foreach(var client in WorldManager.Instance.GetClientsOnMapId(this.Map.Id))
            {
                //update
                client.SendPacket(new GameMapMovementMessage(keyMovements, 2, this.Id));
            }

            this.RolePlayGroupMonsterInformations.disposition.cellId = (int)keyMovements[keyMovements.Count - 1];
        }
    }
}
