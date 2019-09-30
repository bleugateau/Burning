using Burning.Common.Entity;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{

    public class CharacterCharacteristic : AbstractEntity
    {
        public int CharacterId { get; set; }

        public int CapitalPoint { get; set; }

        public int UsedCapitalPoint { get; set; }

        public CharacterBaseCharacteristic fireElementReduction { get; set; }
        public CharacterBaseCharacteristic airElementReduction { get; set; }
        public CharacterBaseCharacteristic waterElementReduction { get; set; }
        public CharacterBaseCharacteristic earthElementReduction { get; set; }
        public CharacterBaseCharacteristic neutralElementReduction { get; set; }
        public CharacterBaseCharacteristic fireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic airElementResistPercent { get; set; }
        public CharacterBaseCharacteristic waterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic pushDamageReduction { get; set; }
        public CharacterBaseCharacteristic earthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic dodgePMLostProbability { get; set; }
        public CharacterBaseCharacteristic dodgePALostProbability { get; set; }
        public CharacterBaseCharacteristic fireDamageBonus { get; set; }
        public CharacterBaseCharacteristic airDamageBonus { get; set; }
        public CharacterBaseCharacteristic waterDamageBonus { get; set; }
        public CharacterBaseCharacteristic earthDamageBonus { get; set; }
        public CharacterBaseCharacteristic neutralDamageBonus { get; set; }
        public CharacterBaseCharacteristic criticalDamageBonus { get; set; }
        public CharacterBaseCharacteristic neutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PMAttack { get; set; }
        public CharacterBaseCharacteristic criticalDamageReduction { get; set; }
        public CharacterBaseCharacteristic pvpEarthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic spellDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic spellDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic weaponDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic weaponDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic rangedDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic rangedDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic pvpNeutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic meleeDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic pvpFireElementReduction { get; set; }
        public CharacterBaseCharacteristic pvpAirElementReduction { get; set; }
        public CharacterBaseCharacteristic pvpWaterElementReduction { get; set; }
        public CharacterBaseCharacteristic pvpEarthElementReduction { get; set; }
        public CharacterBaseCharacteristic pvpNeutralElementReduction { get; set; }
        public CharacterBaseCharacteristic pvpFireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic pvpAirElementResistPercent { get; set; }
        public CharacterBaseCharacteristic pvpWaterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic meleeDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic PAAttack { get; set; }
        public CharacterBaseCharacteristic pushDamageBonus { get; set; }
        public CharacterBaseCharacteristic tackleBlock { get; set; }
        public CharacterBaseCharacteristic actionPoints { get; set; }
        public CharacterBaseCharacteristic prospecting { get; set; }
        public CharacterBaseCharacteristic initiative { get; set; }
        public CharacterBaseCharacteristic tackleEvade { get; set; }
        public CharacterBaseCharacteristic strength { get; set; }
        public CharacterBaseCharacteristic movementPoints { get; set; }
        public CharacterBaseCharacteristic wisdom { get; set; }
        public CharacterBaseCharacteristic permanentDamagePercent { get; set; }
        public CharacterBaseCharacteristic runeBonusPercent { get; set; }
        public CharacterBaseCharacteristic glyphBonusPercent { get; set; }
        public CharacterBaseCharacteristic trapBonusPercent { get; set; }
        public CharacterBaseCharacteristic trapBonus { get; set; }
        public CharacterBaseCharacteristic damagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic vitality { get; set; }
        public CharacterBaseCharacteristic allDamagesBonus { get; set; }
        public CharacterBaseCharacteristic healBonus { get; set; }
        public CharacterBaseCharacteristic weaponDamagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic criticalHit { get; set; }
        public CharacterBaseCharacteristic reflect { get; set; }
        public CharacterBaseCharacteristic summonableCreaturesBoost { get; set; }
        public CharacterBaseCharacteristic range { get; set; }
        public CharacterBaseCharacteristic intelligence { get; set; }
        public CharacterBaseCharacteristic agility { get; set; }
        public CharacterBaseCharacteristic chance { get; set; }
        public CharacterBaseCharacteristic criticalMiss { get; set; }
    }
}
