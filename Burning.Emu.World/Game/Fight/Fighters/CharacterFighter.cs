using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Network;
using Burning.Emu.World.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Fighters
{
    public class CharacterFighter : Fighter
    {
        public Character Character { get; set; }

        public CharacterFighter(TeamEnum team, Character character, int cellId) : base (team)
        {
            this.Id = character.Id;
            this.Character = character;
            this.CellId = cellId;

            var characteristic = character.Characteristics;

            this.AP = characteristic.actionPoints.Total;
            this.PM = characteristic.movementPoints.Total;
            this.Initiative = characteristic.initiative.Total;
            this.Life = characteristic.healBonus.Total + characteristic.LifeBase;
            this.LifeBase = characteristic.healBonus.Total + characteristic.LifeBase;
        }

        public GameFightCharacterInformations GetGameFightCharacterInformations()
        {

            var character = this.Character;
            var characteristic = character.Characteristics;

            GameContextActorPositionInformations positionInformations = new GameContextActorPositionInformations(this.Id, new EntityDispositionInformations(this.CellId, 1));
            GameFightMinimalStats gameFightMinimalStats = new GameFightMinimalStats((uint)this.Life, (uint)this.LifeBase, (uint)this.LifeBase, (uint)characteristic.permanentDamagePercent.Total, (uint)this.ShieldPoints, this.AP, this.AP, this.PM, this.PM, 0, false, characteristic.neutralElementResistPercent.Total, characteristic.earthElementResistPercent.Total, characteristic.waterElementResistPercent.Total,
                characteristic.airElementResistPercent.Total, characteristic.fireElementResistPercent.Total, characteristic.neutralElementReduction.Total, characteristic.earthElementReduction.Total, characteristic.waterElementReduction.Total, characteristic.airElementReduction.Total, characteristic.fireElementReduction.Total,
                characteristic.criticalDamageReduction.Total, characteristic.pushDamageReduction.Total, characteristic.pvpNeutralElementResistPercent.Total, characteristic.pvpEarthElementResistPercent.Total, characteristic.pvpWaterElementResistPercent.Total,
                characteristic.pvpAirElementResistPercent.Total, characteristic.pvpFireElementResistPercent.Total, characteristic.pvpNeutralElementReduction.Total, characteristic.pvpEarthElementReduction.Total, characteristic.pvpWaterElementReduction.Total, characteristic.pvpAirElementReduction.Total, characteristic.pvpFireElementReduction.Total, (uint)characteristic.dodgePALostProbability.Total, (uint)characteristic.dodgePMLostProbability.Total,
                characteristic.tackleBlock.Total, characteristic.tackleEvade.Total, 0, 0, (uint)characteristic.meleeDamageReceivedPercent.Total, (uint)characteristic.rangedDamageReceivedPercent.Total, (uint)characteristic.weaponDamageReceivedPercent.Total, (uint)characteristic.spellDamageReceivedPercent.Total);
            //ActorExtendedAlignmentInformations actorExtendedAlignment = new ActorExtendedAlignmentInformations(0, 0, 0, 0, 0, 0, 0, 0);
            ActorAlignmentInformations actorExtendedAlignment = new ActorAlignmentInformations(0, 0, 0, 0);


            return new GameFightCharacterInformations((double)this.Id, new EntityDispositionInformations(this.CellId, 1), character.Look, new GameContextBasicSpawnInformation(0, true, positionInformations), 0, gameFightMinimalStats, new List<uint>(), character.Name, new PlayerStatus(1), -1, 0, false, (uint)character.Level, actorExtendedAlignment, character.Breed, character.Sex);
        }

        public void ResetFighter()
        {
            var characteristic = this.Character.Characteristics;

            this.AP = characteristic.actionPoints.Total;
            this.PM = characteristic.movementPoints.Total;
        }
    }
}
