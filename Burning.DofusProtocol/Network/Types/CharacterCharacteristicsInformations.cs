using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterCharacteristicsInformations
  {
    public List<CharacterSpellModification> spellModifications = new List<CharacterSpellModification>();
    public const uint Id = 8;
    public double experience;
    public double experienceLevelFloor;
    public double experienceNextLevelFloor;
    public double experienceBonusLimit;
    public double kamas;
    public uint statsPoints;
    public uint additionnalPoints;
    public uint spellsPoints;
    public ActorExtendedAlignmentInformations alignmentInfos;
    public uint lifePoints;
    public uint maxLifePoints;
    public uint energyPoints;
    public uint maxEnergyPoints;
    public int actionPointsCurrent;
    public int movementPointsCurrent;
    public CharacterBaseCharacteristic initiative;
    public CharacterBaseCharacteristic prospecting;
    public CharacterBaseCharacteristic actionPoints;
    public CharacterBaseCharacteristic movementPoints;
    public CharacterBaseCharacteristic strength;
    public CharacterBaseCharacteristic vitality;
    public CharacterBaseCharacteristic wisdom;
    public CharacterBaseCharacteristic chance;
    public CharacterBaseCharacteristic agility;
    public CharacterBaseCharacteristic intelligence;
    public CharacterBaseCharacteristic range;
    public CharacterBaseCharacteristic summonableCreaturesBoost;
    public CharacterBaseCharacteristic reflect;
    public CharacterBaseCharacteristic criticalHit;
    public uint criticalHitWeapon;
    public CharacterBaseCharacteristic criticalMiss;
    public CharacterBaseCharacteristic healBonus;
    public CharacterBaseCharacteristic allDamagesBonus;
    public CharacterBaseCharacteristic weaponDamagesBonusPercent;
    public CharacterBaseCharacteristic damagesBonusPercent;
    public CharacterBaseCharacteristic trapBonus;
    public CharacterBaseCharacteristic trapBonusPercent;
    public CharacterBaseCharacteristic glyphBonusPercent;
    public CharacterBaseCharacteristic runeBonusPercent;
    public CharacterBaseCharacteristic permanentDamagePercent;
    public CharacterBaseCharacteristic tackleBlock;
    public CharacterBaseCharacteristic tackleEvade;
    public CharacterBaseCharacteristic PAAttack;
    public CharacterBaseCharacteristic PMAttack;
    public CharacterBaseCharacteristic pushDamageBonus;
    public CharacterBaseCharacteristic criticalDamageBonus;
    public CharacterBaseCharacteristic neutralDamageBonus;
    public CharacterBaseCharacteristic earthDamageBonus;
    public CharacterBaseCharacteristic waterDamageBonus;
    public CharacterBaseCharacteristic airDamageBonus;
    public CharacterBaseCharacteristic fireDamageBonus;
    public CharacterBaseCharacteristic dodgePALostProbability;
    public CharacterBaseCharacteristic dodgePMLostProbability;
    public CharacterBaseCharacteristic neutralElementResistPercent;
    public CharacterBaseCharacteristic earthElementResistPercent;
    public CharacterBaseCharacteristic waterElementResistPercent;
    public CharacterBaseCharacteristic airElementResistPercent;
    public CharacterBaseCharacteristic fireElementResistPercent;
    public CharacterBaseCharacteristic neutralElementReduction;
    public CharacterBaseCharacteristic earthElementReduction;
    public CharacterBaseCharacteristic waterElementReduction;
    public CharacterBaseCharacteristic airElementReduction;
    public CharacterBaseCharacteristic fireElementReduction;
    public CharacterBaseCharacteristic pushDamageReduction;
    public CharacterBaseCharacteristic criticalDamageReduction;
    public CharacterBaseCharacteristic pvpNeutralElementResistPercent;
    public CharacterBaseCharacteristic pvpEarthElementResistPercent;
    public CharacterBaseCharacteristic pvpWaterElementResistPercent;
    public CharacterBaseCharacteristic pvpAirElementResistPercent;
    public CharacterBaseCharacteristic pvpFireElementResistPercent;
    public CharacterBaseCharacteristic pvpNeutralElementReduction;
    public CharacterBaseCharacteristic pvpEarthElementReduction;
    public CharacterBaseCharacteristic pvpWaterElementReduction;
    public CharacterBaseCharacteristic pvpAirElementReduction;
    public CharacterBaseCharacteristic pvpFireElementReduction;
    public CharacterBaseCharacteristic meleeDamageDonePercent;
    public CharacterBaseCharacteristic meleeDamageReceivedPercent;
    public CharacterBaseCharacteristic rangedDamageDonePercent;
    public CharacterBaseCharacteristic rangedDamageReceivedPercent;
    public CharacterBaseCharacteristic weaponDamageDonePercent;
    public CharacterBaseCharacteristic weaponDamageReceivedPercent;
    public CharacterBaseCharacteristic spellDamageDonePercent;
    public CharacterBaseCharacteristic spellDamageReceivedPercent;
    public uint probationTime;

    public virtual uint TypeId
    {
      get
      {
        return 8;
      }
    }

    public CharacterCharacteristicsInformations()
    {
    }

    public CharacterCharacteristicsInformations(
      double experience,
      double experienceLevelFloor,
      double experienceNextLevelFloor,
      double experienceBonusLimit,
      double kamas,
      uint statsPoints,
      uint additionnalPoints,
      uint spellsPoints,
      ActorExtendedAlignmentInformations alignmentInfos,
      uint lifePoints,
      uint maxLifePoints,
      uint energyPoints,
      uint maxEnergyPoints,
      int actionPointsCurrent,
      int movementPointsCurrent,
      CharacterBaseCharacteristic initiative,
      CharacterBaseCharacteristic prospecting,
      CharacterBaseCharacteristic actionPoints,
      CharacterBaseCharacteristic movementPoints,
      CharacterBaseCharacteristic strength,
      CharacterBaseCharacteristic vitality,
      CharacterBaseCharacteristic wisdom,
      CharacterBaseCharacteristic chance,
      CharacterBaseCharacteristic agility,
      CharacterBaseCharacteristic intelligence,
      CharacterBaseCharacteristic range,
      CharacterBaseCharacteristic summonableCreaturesBoost,
      CharacterBaseCharacteristic reflect,
      CharacterBaseCharacteristic criticalHit,
      uint criticalHitWeapon,
      CharacterBaseCharacteristic criticalMiss,
      CharacterBaseCharacteristic healBonus,
      CharacterBaseCharacteristic allDamagesBonus,
      CharacterBaseCharacteristic weaponDamagesBonusPercent,
      CharacterBaseCharacteristic damagesBonusPercent,
      CharacterBaseCharacteristic trapBonus,
      CharacterBaseCharacteristic trapBonusPercent,
      CharacterBaseCharacteristic glyphBonusPercent,
      CharacterBaseCharacteristic runeBonusPercent,
      CharacterBaseCharacteristic permanentDamagePercent,
      CharacterBaseCharacteristic tackleBlock,
      CharacterBaseCharacteristic tackleEvade,
      CharacterBaseCharacteristic PAAttack,
      CharacterBaseCharacteristic PMAttack,
      CharacterBaseCharacteristic pushDamageBonus,
      CharacterBaseCharacteristic criticalDamageBonus,
      CharacterBaseCharacteristic neutralDamageBonus,
      CharacterBaseCharacteristic earthDamageBonus,
      CharacterBaseCharacteristic waterDamageBonus,
      CharacterBaseCharacteristic airDamageBonus,
      CharacterBaseCharacteristic fireDamageBonus,
      CharacterBaseCharacteristic dodgePALostProbability,
      CharacterBaseCharacteristic dodgePMLostProbability,
      CharacterBaseCharacteristic neutralElementResistPercent,
      CharacterBaseCharacteristic earthElementResistPercent,
      CharacterBaseCharacteristic waterElementResistPercent,
      CharacterBaseCharacteristic airElementResistPercent,
      CharacterBaseCharacteristic fireElementResistPercent,
      CharacterBaseCharacteristic neutralElementReduction,
      CharacterBaseCharacteristic earthElementReduction,
      CharacterBaseCharacteristic waterElementReduction,
      CharacterBaseCharacteristic airElementReduction,
      CharacterBaseCharacteristic fireElementReduction,
      CharacterBaseCharacteristic pushDamageReduction,
      CharacterBaseCharacteristic criticalDamageReduction,
      CharacterBaseCharacteristic pvpNeutralElementResistPercent,
      CharacterBaseCharacteristic pvpEarthElementResistPercent,
      CharacterBaseCharacteristic pvpWaterElementResistPercent,
      CharacterBaseCharacteristic pvpAirElementResistPercent,
      CharacterBaseCharacteristic pvpFireElementResistPercent,
      CharacterBaseCharacteristic pvpNeutralElementReduction,
      CharacterBaseCharacteristic pvpEarthElementReduction,
      CharacterBaseCharacteristic pvpWaterElementReduction,
      CharacterBaseCharacteristic pvpAirElementReduction,
      CharacterBaseCharacteristic pvpFireElementReduction,
      CharacterBaseCharacteristic meleeDamageDonePercent,
      CharacterBaseCharacteristic meleeDamageReceivedPercent,
      CharacterBaseCharacteristic rangedDamageDonePercent,
      CharacterBaseCharacteristic rangedDamageReceivedPercent,
      CharacterBaseCharacteristic weaponDamageDonePercent,
      CharacterBaseCharacteristic weaponDamageReceivedPercent,
      CharacterBaseCharacteristic spellDamageDonePercent,
      CharacterBaseCharacteristic spellDamageReceivedPercent,
      List<CharacterSpellModification> spellModifications,
      uint probationTime)
    {
      this.experience = experience;
      this.experienceLevelFloor = experienceLevelFloor;
      this.experienceNextLevelFloor = experienceNextLevelFloor;
      this.experienceBonusLimit = experienceBonusLimit;
      this.kamas = kamas;
      this.statsPoints = statsPoints;
      this.additionnalPoints = additionnalPoints;
      this.spellsPoints = spellsPoints;
      this.alignmentInfos = alignmentInfos;
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
      this.energyPoints = energyPoints;
      this.maxEnergyPoints = maxEnergyPoints;
      this.actionPointsCurrent = actionPointsCurrent;
      this.movementPointsCurrent = movementPointsCurrent;
      this.initiative = initiative;
      this.prospecting = prospecting;
      this.actionPoints = actionPoints;
      this.movementPoints = movementPoints;
      this.strength = strength;
      this.vitality = vitality;
      this.wisdom = wisdom;
      this.chance = chance;
      this.agility = agility;
      this.intelligence = intelligence;
      this.range = range;
      this.summonableCreaturesBoost = summonableCreaturesBoost;
      this.reflect = reflect;
      this.criticalHit = criticalHit;
      this.criticalHitWeapon = criticalHitWeapon;
      this.criticalMiss = criticalMiss;
      this.healBonus = healBonus;
      this.allDamagesBonus = allDamagesBonus;
      this.weaponDamagesBonusPercent = weaponDamagesBonusPercent;
      this.damagesBonusPercent = damagesBonusPercent;
      this.trapBonus = trapBonus;
      this.trapBonusPercent = trapBonusPercent;
      this.glyphBonusPercent = glyphBonusPercent;
      this.runeBonusPercent = runeBonusPercent;
      this.permanentDamagePercent = permanentDamagePercent;
      this.tackleBlock = tackleBlock;
      this.tackleEvade = tackleEvade;
      this.PAAttack = PAAttack;
      this.PMAttack = PMAttack;
      this.pushDamageBonus = pushDamageBonus;
      this.criticalDamageBonus = criticalDamageBonus;
      this.neutralDamageBonus = neutralDamageBonus;
      this.earthDamageBonus = earthDamageBonus;
      this.waterDamageBonus = waterDamageBonus;
      this.airDamageBonus = airDamageBonus;
      this.fireDamageBonus = fireDamageBonus;
      this.dodgePALostProbability = dodgePALostProbability;
      this.dodgePMLostProbability = dodgePMLostProbability;
      this.neutralElementResistPercent = neutralElementResistPercent;
      this.earthElementResistPercent = earthElementResistPercent;
      this.waterElementResistPercent = waterElementResistPercent;
      this.airElementResistPercent = airElementResistPercent;
      this.fireElementResistPercent = fireElementResistPercent;
      this.neutralElementReduction = neutralElementReduction;
      this.earthElementReduction = earthElementReduction;
      this.waterElementReduction = waterElementReduction;
      this.airElementReduction = airElementReduction;
      this.fireElementReduction = fireElementReduction;
      this.pushDamageReduction = pushDamageReduction;
      this.criticalDamageReduction = criticalDamageReduction;
      this.pvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
      this.pvpEarthElementResistPercent = pvpEarthElementResistPercent;
      this.pvpWaterElementResistPercent = pvpWaterElementResistPercent;
      this.pvpAirElementResistPercent = pvpAirElementResistPercent;
      this.pvpFireElementResistPercent = pvpFireElementResistPercent;
      this.pvpNeutralElementReduction = pvpNeutralElementReduction;
      this.pvpEarthElementReduction = pvpEarthElementReduction;
      this.pvpWaterElementReduction = pvpWaterElementReduction;
      this.pvpAirElementReduction = pvpAirElementReduction;
      this.pvpFireElementReduction = pvpFireElementReduction;
      this.meleeDamageDonePercent = meleeDamageDonePercent;
      this.meleeDamageReceivedPercent = meleeDamageReceivedPercent;
      this.rangedDamageDonePercent = rangedDamageDonePercent;
      this.rangedDamageReceivedPercent = rangedDamageReceivedPercent;
      this.weaponDamageDonePercent = weaponDamageDonePercent;
      this.weaponDamageReceivedPercent = weaponDamageReceivedPercent;
      this.spellDamageDonePercent = spellDamageDonePercent;
      this.spellDamageReceivedPercent = spellDamageReceivedPercent;
      this.spellModifications = spellModifications;
      this.probationTime = probationTime;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.experienceLevelFloor < 0.0 || this.experienceLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceLevelFloor + ") on element experienceLevelFloor.");
      writer.WriteVarLong((long) this.experienceLevelFloor);
      if (this.experienceNextLevelFloor < 0.0 || this.experienceNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceNextLevelFloor + ") on element experienceNextLevelFloor.");
      writer.WriteVarLong((long) this.experienceNextLevelFloor);
      if (this.experienceBonusLimit < 0.0 || this.experienceBonusLimit > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceBonusLimit + ") on element experienceBonusLimit.");
      writer.WriteVarLong((long) this.experienceBonusLimit);
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element kamas.");
      writer.WriteVarLong((long) this.kamas);
      if (this.statsPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.statsPoints + ") on element statsPoints.");
      writer.WriteVarShort((short) this.statsPoints);
      if (this.additionnalPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.additionnalPoints + ") on element additionnalPoints.");
      writer.WriteVarShort((short) this.additionnalPoints);
      if (this.spellsPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellsPoints + ") on element spellsPoints.");
      writer.WriteVarShort((short) this.spellsPoints);
      this.alignmentInfos.Serialize(writer);
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element lifePoints.");
      writer.WriteVarInt((int) this.lifePoints);
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element maxLifePoints.");
      writer.WriteVarInt((int) this.maxLifePoints);
      if (this.energyPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.energyPoints + ") on element energyPoints.");
      writer.WriteVarShort((short) this.energyPoints);
      if (this.maxEnergyPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxEnergyPoints + ") on element maxEnergyPoints.");
      writer.WriteVarShort((short) this.maxEnergyPoints);
      writer.WriteVarShort((short) this.actionPointsCurrent);
      writer.WriteVarShort((short) this.movementPointsCurrent);
      this.initiative.Serialize(writer);
      this.prospecting.Serialize(writer);
      this.actionPoints.Serialize(writer);
      this.movementPoints.Serialize(writer);
      this.strength.Serialize(writer);
      this.vitality.Serialize(writer);
      this.wisdom.Serialize(writer);
      this.chance.Serialize(writer);
      this.agility.Serialize(writer);
      this.intelligence.Serialize(writer);
      this.range.Serialize(writer);
      this.summonableCreaturesBoost.Serialize(writer);
      this.reflect.Serialize(writer);
      this.criticalHit.Serialize(writer);
      if (this.criticalHitWeapon < 0U)
        throw new Exception("Forbidden value (" + (object) this.criticalHitWeapon + ") on element criticalHitWeapon.");
      writer.WriteVarShort((short) this.criticalHitWeapon);
      this.criticalMiss.Serialize(writer);
      this.healBonus.Serialize(writer);
      this.allDamagesBonus.Serialize(writer);
      this.weaponDamagesBonusPercent.Serialize(writer);
      this.damagesBonusPercent.Serialize(writer);
      this.trapBonus.Serialize(writer);
      this.trapBonusPercent.Serialize(writer);
      this.glyphBonusPercent.Serialize(writer);
      this.runeBonusPercent.Serialize(writer);
      this.permanentDamagePercent.Serialize(writer);
      this.tackleBlock.Serialize(writer);
      this.tackleEvade.Serialize(writer);
      this.PAAttack.Serialize(writer);
      this.PMAttack.Serialize(writer);
      this.pushDamageBonus.Serialize(writer);
      this.criticalDamageBonus.Serialize(writer);
      this.neutralDamageBonus.Serialize(writer);
      this.earthDamageBonus.Serialize(writer);
      this.waterDamageBonus.Serialize(writer);
      this.airDamageBonus.Serialize(writer);
      this.fireDamageBonus.Serialize(writer);
      this.dodgePALostProbability.Serialize(writer);
      this.dodgePMLostProbability.Serialize(writer);
      this.neutralElementResistPercent.Serialize(writer);
      this.earthElementResistPercent.Serialize(writer);
      this.waterElementResistPercent.Serialize(writer);
      this.airElementResistPercent.Serialize(writer);
      this.fireElementResistPercent.Serialize(writer);
      this.neutralElementReduction.Serialize(writer);
      this.earthElementReduction.Serialize(writer);
      this.waterElementReduction.Serialize(writer);
      this.airElementReduction.Serialize(writer);
      this.fireElementReduction.Serialize(writer);
      this.pushDamageReduction.Serialize(writer);
      this.criticalDamageReduction.Serialize(writer);
      this.pvpNeutralElementResistPercent.Serialize(writer);
      this.pvpEarthElementResistPercent.Serialize(writer);
      this.pvpWaterElementResistPercent.Serialize(writer);
      this.pvpAirElementResistPercent.Serialize(writer);
      this.pvpFireElementResistPercent.Serialize(writer);
      this.pvpNeutralElementReduction.Serialize(writer);
      this.pvpEarthElementReduction.Serialize(writer);
      this.pvpWaterElementReduction.Serialize(writer);
      this.pvpAirElementReduction.Serialize(writer);
      this.pvpFireElementReduction.Serialize(writer);
      this.meleeDamageDonePercent.Serialize(writer);
      this.meleeDamageReceivedPercent.Serialize(writer);
      this.rangedDamageDonePercent.Serialize(writer);
      this.rangedDamageReceivedPercent.Serialize(writer);
      this.weaponDamageDonePercent.Serialize(writer);
      this.weaponDamageReceivedPercent.Serialize(writer);
      this.spellDamageDonePercent.Serialize(writer);
      this.spellDamageReceivedPercent.Serialize(writer);
      writer.WriteShort((short) this.spellModifications.Count);
      for (int index = 0; index < this.spellModifications.Count; ++index)
        this.spellModifications[index].Serialize(writer);
      if (this.probationTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.probationTime + ") on element probationTime.");
      writer.WriteInt((int) this.probationTime);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of CharacterCharacteristicsInformations.experience.");
      this.experienceLevelFloor = (double) reader.ReadVarUhLong();
      if (this.experienceLevelFloor < 0.0 || this.experienceLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceLevelFloor + ") on element of CharacterCharacteristicsInformations.experienceLevelFloor.");
      this.experienceNextLevelFloor = (double) reader.ReadVarUhLong();
      if (this.experienceNextLevelFloor < 0.0 || this.experienceNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceNextLevelFloor + ") on element of CharacterCharacteristicsInformations.experienceNextLevelFloor.");
      this.experienceBonusLimit = (double) reader.ReadVarUhLong();
      if (this.experienceBonusLimit < 0.0 || this.experienceBonusLimit > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experienceBonusLimit + ") on element of CharacterCharacteristicsInformations.experienceBonusLimit.");
      this.kamas = (double) reader.ReadVarUhLong();
      if (this.kamas < 0.0 || this.kamas > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamas + ") on element of CharacterCharacteristicsInformations.kamas.");
      this.statsPoints = (uint) reader.ReadVarUhShort();
      if (this.statsPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.statsPoints + ") on element of CharacterCharacteristicsInformations.statsPoints.");
      this.additionnalPoints = (uint) reader.ReadVarUhShort();
      if (this.additionnalPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.additionnalPoints + ") on element of CharacterCharacteristicsInformations.additionnalPoints.");
      this.spellsPoints = (uint) reader.ReadVarUhShort();
      if (this.spellsPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellsPoints + ") on element of CharacterCharacteristicsInformations.spellsPoints.");
      this.alignmentInfos = new ActorExtendedAlignmentInformations();
      this.alignmentInfos.Deserialize(reader);
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of CharacterCharacteristicsInformations.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of CharacterCharacteristicsInformations.maxLifePoints.");
      this.energyPoints = (uint) reader.ReadVarUhShort();
      if (this.energyPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.energyPoints + ") on element of CharacterCharacteristicsInformations.energyPoints.");
      this.maxEnergyPoints = (uint) reader.ReadVarUhShort();
      if (this.maxEnergyPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxEnergyPoints + ") on element of CharacterCharacteristicsInformations.maxEnergyPoints.");
      this.actionPointsCurrent = (int) reader.ReadVarShort();
      this.movementPointsCurrent = (int) reader.ReadVarShort();
      this.initiative = new CharacterBaseCharacteristic();
      this.initiative.Deserialize(reader);
      this.prospecting = new CharacterBaseCharacteristic();
      this.prospecting.Deserialize(reader);
      this.actionPoints = new CharacterBaseCharacteristic();
      this.actionPoints.Deserialize(reader);
      this.movementPoints = new CharacterBaseCharacteristic();
      this.movementPoints.Deserialize(reader);
      this.strength = new CharacterBaseCharacteristic();
      this.strength.Deserialize(reader);
      this.vitality = new CharacterBaseCharacteristic();
      this.vitality.Deserialize(reader);
      this.wisdom = new CharacterBaseCharacteristic();
      this.wisdom.Deserialize(reader);
      this.chance = new CharacterBaseCharacteristic();
      this.chance.Deserialize(reader);
      this.agility = new CharacterBaseCharacteristic();
      this.agility.Deserialize(reader);
      this.intelligence = new CharacterBaseCharacteristic();
      this.intelligence.Deserialize(reader);
      this.range = new CharacterBaseCharacteristic();
      this.range.Deserialize(reader);
      this.summonableCreaturesBoost = new CharacterBaseCharacteristic();
      this.summonableCreaturesBoost.Deserialize(reader);
      this.reflect = new CharacterBaseCharacteristic();
      this.reflect.Deserialize(reader);
      this.criticalHit = new CharacterBaseCharacteristic();
      this.criticalHit.Deserialize(reader);
      this.criticalHitWeapon = (uint) reader.ReadVarUhShort();
      if (this.criticalHitWeapon < 0U)
        throw new Exception("Forbidden value (" + (object) this.criticalHitWeapon + ") on element of CharacterCharacteristicsInformations.criticalHitWeapon.");
      this.criticalMiss = new CharacterBaseCharacteristic();
      this.criticalMiss.Deserialize(reader);
      this.healBonus = new CharacterBaseCharacteristic();
      this.healBonus.Deserialize(reader);
      this.allDamagesBonus = new CharacterBaseCharacteristic();
      this.allDamagesBonus.Deserialize(reader);
      this.weaponDamagesBonusPercent = new CharacterBaseCharacteristic();
      this.weaponDamagesBonusPercent.Deserialize(reader);
      this.damagesBonusPercent = new CharacterBaseCharacteristic();
      this.damagesBonusPercent.Deserialize(reader);
      this.trapBonus = new CharacterBaseCharacteristic();
      this.trapBonus.Deserialize(reader);
      this.trapBonusPercent = new CharacterBaseCharacteristic();
      this.trapBonusPercent.Deserialize(reader);
      this.glyphBonusPercent = new CharacterBaseCharacteristic();
      this.glyphBonusPercent.Deserialize(reader);
      this.runeBonusPercent = new CharacterBaseCharacteristic();
      this.runeBonusPercent.Deserialize(reader);
      this.permanentDamagePercent = new CharacterBaseCharacteristic();
      this.permanentDamagePercent.Deserialize(reader);
      this.tackleBlock = new CharacterBaseCharacteristic();
      this.tackleBlock.Deserialize(reader);
      this.tackleEvade = new CharacterBaseCharacteristic();
      this.tackleEvade.Deserialize(reader);
      this.PAAttack = new CharacterBaseCharacteristic();
      this.PAAttack.Deserialize(reader);
      this.PMAttack = new CharacterBaseCharacteristic();
      this.PMAttack.Deserialize(reader);
      this.pushDamageBonus = new CharacterBaseCharacteristic();
      this.pushDamageBonus.Deserialize(reader);
      this.criticalDamageBonus = new CharacterBaseCharacteristic();
      this.criticalDamageBonus.Deserialize(reader);
      this.neutralDamageBonus = new CharacterBaseCharacteristic();
      this.neutralDamageBonus.Deserialize(reader);
      this.earthDamageBonus = new CharacterBaseCharacteristic();
      this.earthDamageBonus.Deserialize(reader);
      this.waterDamageBonus = new CharacterBaseCharacteristic();
      this.waterDamageBonus.Deserialize(reader);
      this.airDamageBonus = new CharacterBaseCharacteristic();
      this.airDamageBonus.Deserialize(reader);
      this.fireDamageBonus = new CharacterBaseCharacteristic();
      this.fireDamageBonus.Deserialize(reader);
      this.dodgePALostProbability = new CharacterBaseCharacteristic();
      this.dodgePALostProbability.Deserialize(reader);
      this.dodgePMLostProbability = new CharacterBaseCharacteristic();
      this.dodgePMLostProbability.Deserialize(reader);
      this.neutralElementResistPercent = new CharacterBaseCharacteristic();
      this.neutralElementResistPercent.Deserialize(reader);
      this.earthElementResistPercent = new CharacterBaseCharacteristic();
      this.earthElementResistPercent.Deserialize(reader);
      this.waterElementResistPercent = new CharacterBaseCharacteristic();
      this.waterElementResistPercent.Deserialize(reader);
      this.airElementResistPercent = new CharacterBaseCharacteristic();
      this.airElementResistPercent.Deserialize(reader);
      this.fireElementResistPercent = new CharacterBaseCharacteristic();
      this.fireElementResistPercent.Deserialize(reader);
      this.neutralElementReduction = new CharacterBaseCharacteristic();
      this.neutralElementReduction.Deserialize(reader);
      this.earthElementReduction = new CharacterBaseCharacteristic();
      this.earthElementReduction.Deserialize(reader);
      this.waterElementReduction = new CharacterBaseCharacteristic();
      this.waterElementReduction.Deserialize(reader);
      this.airElementReduction = new CharacterBaseCharacteristic();
      this.airElementReduction.Deserialize(reader);
      this.fireElementReduction = new CharacterBaseCharacteristic();
      this.fireElementReduction.Deserialize(reader);
      this.pushDamageReduction = new CharacterBaseCharacteristic();
      this.pushDamageReduction.Deserialize(reader);
      this.criticalDamageReduction = new CharacterBaseCharacteristic();
      this.criticalDamageReduction.Deserialize(reader);
      this.pvpNeutralElementResistPercent = new CharacterBaseCharacteristic();
      this.pvpNeutralElementResistPercent.Deserialize(reader);
      this.pvpEarthElementResistPercent = new CharacterBaseCharacteristic();
      this.pvpEarthElementResistPercent.Deserialize(reader);
      this.pvpWaterElementResistPercent = new CharacterBaseCharacteristic();
      this.pvpWaterElementResistPercent.Deserialize(reader);
      this.pvpAirElementResistPercent = new CharacterBaseCharacteristic();
      this.pvpAirElementResistPercent.Deserialize(reader);
      this.pvpFireElementResistPercent = new CharacterBaseCharacteristic();
      this.pvpFireElementResistPercent.Deserialize(reader);
      this.pvpNeutralElementReduction = new CharacterBaseCharacteristic();
      this.pvpNeutralElementReduction.Deserialize(reader);
      this.pvpEarthElementReduction = new CharacterBaseCharacteristic();
      this.pvpEarthElementReduction.Deserialize(reader);
      this.pvpWaterElementReduction = new CharacterBaseCharacteristic();
      this.pvpWaterElementReduction.Deserialize(reader);
      this.pvpAirElementReduction = new CharacterBaseCharacteristic();
      this.pvpAirElementReduction.Deserialize(reader);
      this.pvpFireElementReduction = new CharacterBaseCharacteristic();
      this.pvpFireElementReduction.Deserialize(reader);
      this.meleeDamageDonePercent = new CharacterBaseCharacteristic();
      this.meleeDamageDonePercent.Deserialize(reader);
      this.meleeDamageReceivedPercent = new CharacterBaseCharacteristic();
      this.meleeDamageReceivedPercent.Deserialize(reader);
      this.rangedDamageDonePercent = new CharacterBaseCharacteristic();
      this.rangedDamageDonePercent.Deserialize(reader);
      this.rangedDamageReceivedPercent = new CharacterBaseCharacteristic();
      this.rangedDamageReceivedPercent.Deserialize(reader);
      this.weaponDamageDonePercent = new CharacterBaseCharacteristic();
      this.weaponDamageDonePercent.Deserialize(reader);
      this.weaponDamageReceivedPercent = new CharacterBaseCharacteristic();
      this.weaponDamageReceivedPercent.Deserialize(reader);
      this.spellDamageDonePercent = new CharacterBaseCharacteristic();
      this.spellDamageDonePercent.Deserialize(reader);
      this.spellDamageReceivedPercent = new CharacterBaseCharacteristic();
      this.spellDamageReceivedPercent.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterSpellModification spellModification = new CharacterSpellModification();
        spellModification.Deserialize(reader);
        this.spellModifications.Add(spellModification);
      }
      this.probationTime = (uint) reader.ReadInt();
      if (this.probationTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.probationTime + ") on element of CharacterCharacteristicsInformations.probationTime.");
    }
  }
}
