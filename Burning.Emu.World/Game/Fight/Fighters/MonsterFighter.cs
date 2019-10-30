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

        public MonsterFighter(int id, TeamEnum team, Burning.DofusProtocol.Datacenter.Monster monster, int cellId) : base (team)
        {
            this.Id = id;
            this.CellId = cellId;
            this.Monster = monster;


            this.Life = monster.Grades[0].LifePoints;
            this.LifeBase = monster.Grades[0].LifePoints;
            this.AP = monster.Grades[0].ActionPoints;
            this.PM = monster.Grades[0].MovementPoints;
            this.Initiative = (monster.Grades[0].Agility + monster.Grades[0].Chance + monster.Grades[0].Intelligence + monster.Grades[0].Strength + monster.Grades[0].Vitality + monster.Grades[0].Wisdom);


            this.Agility = monster.Grades[0].Agility;
            this.Water = monster.Grades[0].Chance;
            this.Intelligence = monster.Grades[0].Intelligence;
            this.Strength = monster.Grades[0].Strength;
            this.Wisdom = monster.Grades[0].Wisdom;

            this.AgilityPercentResistance = monster.Grades[0].AirResistance;
            this.WaterPercentResistance = monster.Grades[0].WaterResistance;
            this.StrengthPercentResistance = monster.Grades[0].EarthResistance;
            this.NeutralPercentResistance = monster.Grades[0].NeutralResistance;
            this.IntelligencePercentResistance = monster.Grades[0].FireResistance;

        }

        public GameFightMonsterInformations GetGameFightMonsterInformations()
        {
            GameContextActorPositionInformations positionInformations = new GameContextActorPositionInformations((double)this.Id, new EntityDispositionInformations(this.CellId, 1));

            var characteristics = this.Monster.Grades[0];

            GameFightMinimalStats gameFightMinimalStats =

                this.Fight != null && this.Fight.FightState == FightStateEnum.FIGHT_CHOICE_PLACEMENT ?

                new GameFightMinimalStatsPreparation((uint)this.Life, (uint)this.LifeBase, (uint)this.LifeBase, 0, (uint)this.ShieldPoints, this.AP, characteristics.ActionPoints, this.PM, characteristics.MovementPoints, 0, false,
                this.NeutralPercentResistance, this.StrengthPercentResistance, this.WaterPercentResistance, this.AgilityPercentResistance, this.IntelligencePercentResistance, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (uint)GameActionFightInvisibilityStateEnum.VISIBLE, 100, 100, 100, 100, (uint)this.Initiative)

                :

                new GameFightMinimalStats((uint)this.Life, (uint)this.LifeBase, (uint)this.LifeBase, 0, (uint)this.ShieldPoints, this.AP, characteristics.ActionPoints, this.PM, characteristics.MovementPoints, 0, false,
                this.NeutralPercentResistance, this.StrengthPercentResistance, this.WaterPercentResistance, this.AgilityPercentResistance, this.IntelligencePercentResistance, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (uint)GameActionFightInvisibilityStateEnum.VISIBLE, 100, 100, 100, 100);

            return new GameFightMonsterInformations((double)this.Id, new EntityDispositionInformations(this.CellId, 1), Look.Parse(this.Monster.Look).GetEntityLook(), new GameContextBasicSpawnInformation(1, true, positionInformations), 0, gameFightMinimalStats, new List<uint>(), (uint)this.Monster.Id, this.Monster.Grades[0].Grade, this.Monster.Grades[0].Level);
        }
    }
}
