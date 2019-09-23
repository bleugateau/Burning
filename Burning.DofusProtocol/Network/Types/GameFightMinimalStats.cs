using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightMinimalStats
  {
    public const uint Id = 31;
    public uint lifePoints;
    public uint maxLifePoints;
    public uint baseMaxLifePoints;
    public uint permanentDamagePercent;
    public uint shieldPoints;
    public int actionPoints;
    public int maxActionPoints;
    public int movementPoints;
    public int maxMovementPoints;
    public double summoner;
    public bool summoned;
    public int neutralElementResistPercent;
    public int earthElementResistPercent;
    public int waterElementResistPercent;
    public int airElementResistPercent;
    public int fireElementResistPercent;
    public int neutralElementReduction;
    public int earthElementReduction;
    public int waterElementReduction;
    public int airElementReduction;
    public int fireElementReduction;
    public int criticalDamageFixedResist;
    public int pushDamageFixedResist;
    public int pvpNeutralElementResistPercent;
    public int pvpEarthElementResistPercent;
    public int pvpWaterElementResistPercent;
    public int pvpAirElementResistPercent;
    public int pvpFireElementResistPercent;
    public int pvpNeutralElementReduction;
    public int pvpEarthElementReduction;
    public int pvpWaterElementReduction;
    public int pvpAirElementReduction;
    public int pvpFireElementReduction;
    public uint dodgePALostProbability;
    public uint dodgePMLostProbability;
    public int tackleBlock;
    public int tackleEvade;
    public int fixedDamageReflection;
    public uint invisibilityState;
    public uint meleeDamageReceivedPercent;
    public uint rangedDamageReceivedPercent;
    public uint weaponDamageReceivedPercent;
    public uint spellDamageReceivedPercent;

    public virtual uint TypeId
    {
      get
      {
        return 31;
      }
    }

    public GameFightMinimalStats()
    {
    }

    public GameFightMinimalStats(
      uint lifePoints,
      uint maxLifePoints,
      uint baseMaxLifePoints,
      uint permanentDamagePercent,
      uint shieldPoints,
      int actionPoints,
      int maxActionPoints,
      int movementPoints,
      int maxMovementPoints,
      double summoner,
      bool summoned,
      int neutralElementResistPercent,
      int earthElementResistPercent,
      int waterElementResistPercent,
      int airElementResistPercent,
      int fireElementResistPercent,
      int neutralElementReduction,
      int earthElementReduction,
      int waterElementReduction,
      int airElementReduction,
      int fireElementReduction,
      int criticalDamageFixedResist,
      int pushDamageFixedResist,
      int pvpNeutralElementResistPercent,
      int pvpEarthElementResistPercent,
      int pvpWaterElementResistPercent,
      int pvpAirElementResistPercent,
      int pvpFireElementResistPercent,
      int pvpNeutralElementReduction,
      int pvpEarthElementReduction,
      int pvpWaterElementReduction,
      int pvpAirElementReduction,
      int pvpFireElementReduction,
      uint dodgePALostProbability,
      uint dodgePMLostProbability,
      int tackleBlock,
      int tackleEvade,
      int fixedDamageReflection,
      uint invisibilityState,
      uint meleeDamageReceivedPercent,
      uint rangedDamageReceivedPercent,
      uint weaponDamageReceivedPercent,
      uint spellDamageReceivedPercent)
    {
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
      this.baseMaxLifePoints = baseMaxLifePoints;
      this.permanentDamagePercent = permanentDamagePercent;
      this.shieldPoints = shieldPoints;
      this.actionPoints = actionPoints;
      this.maxActionPoints = maxActionPoints;
      this.movementPoints = movementPoints;
      this.maxMovementPoints = maxMovementPoints;
      this.summoner = summoner;
      this.summoned = summoned;
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
      this.criticalDamageFixedResist = criticalDamageFixedResist;
      this.pushDamageFixedResist = pushDamageFixedResist;
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
      this.dodgePALostProbability = dodgePALostProbability;
      this.dodgePMLostProbability = dodgePMLostProbability;
      this.tackleBlock = tackleBlock;
      this.tackleEvade = tackleEvade;
      this.fixedDamageReflection = fixedDamageReflection;
      this.invisibilityState = invisibilityState;
      this.meleeDamageReceivedPercent = meleeDamageReceivedPercent;
      this.rangedDamageReceivedPercent = rangedDamageReceivedPercent;
      this.weaponDamageReceivedPercent = weaponDamageReceivedPercent;
      this.spellDamageReceivedPercent = spellDamageReceivedPercent;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element lifePoints.");
      writer.WriteVarInt((int) this.lifePoints);
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element maxLifePoints.");
      writer.WriteVarInt((int) this.maxLifePoints);
      if (this.baseMaxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.baseMaxLifePoints + ") on element baseMaxLifePoints.");
      writer.WriteVarInt((int) this.baseMaxLifePoints);
      if (this.permanentDamagePercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.permanentDamagePercent + ") on element permanentDamagePercent.");
      writer.WriteVarInt((int) this.permanentDamagePercent);
      if (this.shieldPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.shieldPoints + ") on element shieldPoints.");
      writer.WriteVarInt((int) this.shieldPoints);
      writer.WriteVarShort((short) this.actionPoints);
      writer.WriteVarShort((short) this.maxActionPoints);
      writer.WriteVarShort((short) this.movementPoints);
      writer.WriteVarShort((short) this.maxMovementPoints);
      if (this.summoner < -9.00719925474099E+15 || this.summoner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.summoner + ") on element summoner.");
      writer.WriteDouble(this.summoner);
      writer.WriteBoolean(this.summoned);
      writer.WriteVarShort((short) this.neutralElementResistPercent);
      writer.WriteVarShort((short) this.earthElementResistPercent);
      writer.WriteVarShort((short) this.waterElementResistPercent);
      writer.WriteVarShort((short) this.airElementResistPercent);
      writer.WriteVarShort((short) this.fireElementResistPercent);
      writer.WriteVarShort((short) this.neutralElementReduction);
      writer.WriteVarShort((short) this.earthElementReduction);
      writer.WriteVarShort((short) this.waterElementReduction);
      writer.WriteVarShort((short) this.airElementReduction);
      writer.WriteVarShort((short) this.fireElementReduction);
      writer.WriteVarShort((short) this.criticalDamageFixedResist);
      writer.WriteVarShort((short) this.pushDamageFixedResist);
      writer.WriteVarShort((short) this.pvpNeutralElementResistPercent);
      writer.WriteVarShort((short) this.pvpEarthElementResistPercent);
      writer.WriteVarShort((short) this.pvpWaterElementResistPercent);
      writer.WriteVarShort((short) this.pvpAirElementResistPercent);
      writer.WriteVarShort((short) this.pvpFireElementResistPercent);
      writer.WriteVarShort((short) this.pvpNeutralElementReduction);
      writer.WriteVarShort((short) this.pvpEarthElementReduction);
      writer.WriteVarShort((short) this.pvpWaterElementReduction);
      writer.WriteVarShort((short) this.pvpAirElementReduction);
      writer.WriteVarShort((short) this.pvpFireElementReduction);
      if (this.dodgePALostProbability < 0U)
        throw new Exception("Forbidden value (" + (object) this.dodgePALostProbability + ") on element dodgePALostProbability.");
      writer.WriteVarShort((short) this.dodgePALostProbability);
      if (this.dodgePMLostProbability < 0U)
        throw new Exception("Forbidden value (" + (object) this.dodgePMLostProbability + ") on element dodgePMLostProbability.");
      writer.WriteVarShort((short) this.dodgePMLostProbability);
      writer.WriteVarShort((short) this.tackleBlock);
      writer.WriteVarShort((short) this.tackleEvade);
      writer.WriteVarShort((short) this.fixedDamageReflection);
      writer.WriteByte((byte) this.invisibilityState);
      if (this.meleeDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.meleeDamageReceivedPercent + ") on element meleeDamageReceivedPercent.");
      writer.WriteVarShort((short) this.meleeDamageReceivedPercent);
      if (this.rangedDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.rangedDamageReceivedPercent + ") on element rangedDamageReceivedPercent.");
      writer.WriteVarShort((short) this.rangedDamageReceivedPercent);
      if (this.weaponDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.weaponDamageReceivedPercent + ") on element weaponDamageReceivedPercent.");
      writer.WriteVarShort((short) this.weaponDamageReceivedPercent);
      if (this.spellDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellDamageReceivedPercent + ") on element spellDamageReceivedPercent.");
      writer.WriteVarShort((short) this.spellDamageReceivedPercent);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of GameFightMinimalStats.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of GameFightMinimalStats.maxLifePoints.");
      this.baseMaxLifePoints = reader.ReadVarUhInt();
      if (this.baseMaxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.baseMaxLifePoints + ") on element of GameFightMinimalStats.baseMaxLifePoints.");
      this.permanentDamagePercent = reader.ReadVarUhInt();
      if (this.permanentDamagePercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.permanentDamagePercent + ") on element of GameFightMinimalStats.permanentDamagePercent.");
      this.shieldPoints = reader.ReadVarUhInt();
      if (this.shieldPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.shieldPoints + ") on element of GameFightMinimalStats.shieldPoints.");
      this.actionPoints = (int) reader.ReadVarShort();
      this.maxActionPoints = (int) reader.ReadVarShort();
      this.movementPoints = (int) reader.ReadVarShort();
      this.maxMovementPoints = (int) reader.ReadVarShort();
      this.summoner = reader.ReadDouble();
      if (this.summoner < -9.00719925474099E+15 || this.summoner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.summoner + ") on element of GameFightMinimalStats.summoner.");
      this.summoned = reader.ReadBoolean();
      this.neutralElementResistPercent = (int) reader.ReadVarShort();
      this.earthElementResistPercent = (int) reader.ReadVarShort();
      this.waterElementResistPercent = (int) reader.ReadVarShort();
      this.airElementResistPercent = (int) reader.ReadVarShort();
      this.fireElementResistPercent = (int) reader.ReadVarShort();
      this.neutralElementReduction = (int) reader.ReadVarShort();
      this.earthElementReduction = (int) reader.ReadVarShort();
      this.waterElementReduction = (int) reader.ReadVarShort();
      this.airElementReduction = (int) reader.ReadVarShort();
      this.fireElementReduction = (int) reader.ReadVarShort();
      this.criticalDamageFixedResist = (int) reader.ReadVarShort();
      this.pushDamageFixedResist = (int) reader.ReadVarShort();
      this.pvpNeutralElementResistPercent = (int) reader.ReadVarShort();
      this.pvpEarthElementResistPercent = (int) reader.ReadVarShort();
      this.pvpWaterElementResistPercent = (int) reader.ReadVarShort();
      this.pvpAirElementResistPercent = (int) reader.ReadVarShort();
      this.pvpFireElementResistPercent = (int) reader.ReadVarShort();
      this.pvpNeutralElementReduction = (int) reader.ReadVarShort();
      this.pvpEarthElementReduction = (int) reader.ReadVarShort();
      this.pvpWaterElementReduction = (int) reader.ReadVarShort();
      this.pvpAirElementReduction = (int) reader.ReadVarShort();
      this.pvpFireElementReduction = (int) reader.ReadVarShort();
      this.dodgePALostProbability = (uint) reader.ReadVarUhShort();
      if (this.dodgePALostProbability < 0U)
        throw new Exception("Forbidden value (" + (object) this.dodgePALostProbability + ") on element of GameFightMinimalStats.dodgePALostProbability.");
      this.dodgePMLostProbability = (uint) reader.ReadVarUhShort();
      if (this.dodgePMLostProbability < 0U)
        throw new Exception("Forbidden value (" + (object) this.dodgePMLostProbability + ") on element of GameFightMinimalStats.dodgePMLostProbability.");
      this.tackleBlock = (int) reader.ReadVarShort();
      this.tackleEvade = (int) reader.ReadVarShort();
      this.fixedDamageReflection = (int) reader.ReadVarShort();
      this.invisibilityState = (uint) reader.ReadByte();
      if (this.invisibilityState < 0U)
        throw new Exception("Forbidden value (" + (object) this.invisibilityState + ") on element of GameFightMinimalStats.invisibilityState.");
      this.meleeDamageReceivedPercent = (uint) reader.ReadVarUhShort();
      if (this.meleeDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.meleeDamageReceivedPercent + ") on element of GameFightMinimalStats.meleeDamageReceivedPercent.");
      this.rangedDamageReceivedPercent = (uint) reader.ReadVarUhShort();
      if (this.rangedDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.rangedDamageReceivedPercent + ") on element of GameFightMinimalStats.rangedDamageReceivedPercent.");
      this.weaponDamageReceivedPercent = (uint) reader.ReadVarUhShort();
      if (this.weaponDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.weaponDamageReceivedPercent + ") on element of GameFightMinimalStats.weaponDamageReceivedPercent.");
      this.spellDamageReceivedPercent = (uint) reader.ReadVarUhShort();
      if (this.spellDamageReceivedPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellDamageReceivedPercent + ") on element of GameFightMinimalStats.spellDamageReceivedPercent.");
    }
  }
}
