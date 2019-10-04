using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;

namespace Burning.Emu.World.Game.Fight.Fighters
{
    public class MonsterFighter : Fighter
    {
        public Burning.DofusProtocol.Datacenter.Monster Monster { get; set; }

        public MonsterFighter(Burning.DofusProtocol.Datacenter.Monster monster, int cellId)
        {
            this.Id = cellId * -1;
            this.CellId = cellId;
            this.Monster = monster;

            this.Life = monster.Grades[0].LifePoints;
            this.LifeBase = monster.Grades[0].LifePoints;
            this.AP = monster.Grades[0].ActionPoints;
            this.PM = monster.Grades[0].MovementPoints;
            this.Initiative = (monster.Grades[0].Agility + monster.Grades[0].Chance + monster.Grades[0].Intelligence + monster.Grades[0].Strength + monster.Grades[0].Vitality + monster.Grades[0].Wisdom);
        }

        public GameFightMonsterInformations GetGameFightMonsterInformations()
        {
            GameContextActorPositionInformations positionInformations = new GameContextActorPositionInformations(this.Id, new EntityDispositionInformations(this.CellId, 1));
            GameFightMinimalStats gameFightMinimalStats = new GameFightMinimalStats();

            return new GameFightMonsterInformations(this.Id, new EntityDispositionInformations(this.CellId, 1), Look.Parse(this.Monster.Look).GetEntityLook(), new GameContextBasicSpawnInformation(1, true, positionInformations), 0, gameFightMinimalStats, new List<uint>(), (uint)this.Monster.Id, this.Monster.Grades[0].Grade, this.Monster.Grades[0].Level);
        }
    }
}
