using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightMinimalStatsPreparation : GameFightMinimalStats
  {
    public new const uint Id = 360;
    public uint initiative;

    public override uint TypeId
    {
      get
      {
        return 360;
      }
    }

    public GameFightMinimalStatsPreparation()
    {
    }

    public GameFightMinimalStatsPreparation(
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
      uint spellDamageReceivedPercent,
      uint initiative)
      : base(lifePoints, maxLifePoints, baseMaxLifePoints, permanentDamagePercent, shieldPoints, actionPoints, maxActionPoints, movementPoints, maxMovementPoints, summoner, summoned, neutralElementResistPercent, earthElementResistPercent, waterElementResistPercent, airElementResistPercent, fireElementResistPercent, neutralElementReduction, earthElementReduction, waterElementReduction, airElementReduction, fireElementReduction, criticalDamageFixedResist, pushDamageFixedResist, pvpNeutralElementResistPercent, pvpEarthElementResistPercent, pvpWaterElementResistPercent, pvpAirElementResistPercent, pvpFireElementResistPercent, pvpNeutralElementReduction, pvpEarthElementReduction, pvpWaterElementReduction, pvpAirElementReduction, pvpFireElementReduction, dodgePALostProbability, dodgePMLostProbability, tackleBlock, tackleEvade, fixedDamageReflection, invisibilityState, meleeDamageReceivedPercent, rangedDamageReceivedPercent, weaponDamageReceivedPercent, spellDamageReceivedPercent)
    {
      this.initiative = initiative;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element initiative.");
      writer.WriteVarInt((int) this.initiative);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.initiative = reader.ReadVarUhInt();
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element of GameFightMinimalStatsPreparation.initiative.");
    }
  }
}
