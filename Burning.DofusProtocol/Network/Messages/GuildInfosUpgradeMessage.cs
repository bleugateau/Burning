using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInfosUpgradeMessage : NetworkMessage
  {
    public List<uint> spellId = new List<uint>();
    public List<int> spellLevel = new List<int>();
    public const uint Id = 5636;
    public uint maxTaxCollectorsCount;
    public uint taxCollectorsCount;
    public uint taxCollectorLifePoints;
    public uint taxCollectorDamagesBonuses;
    public uint taxCollectorPods;
    public uint taxCollectorProspecting;
    public uint taxCollectorWisdom;
    public uint boostPoints;

    public override uint MessageId
    {
      get
      {
        return 5636;
      }
    }

    public GuildInfosUpgradeMessage()
    {
    }

    public GuildInfosUpgradeMessage(
      uint maxTaxCollectorsCount,
      uint taxCollectorsCount,
      uint taxCollectorLifePoints,
      uint taxCollectorDamagesBonuses,
      uint taxCollectorPods,
      uint taxCollectorProspecting,
      uint taxCollectorWisdom,
      uint boostPoints,
      List<uint> spellId,
      List<int> spellLevel)
    {
      this.maxTaxCollectorsCount = maxTaxCollectorsCount;
      this.taxCollectorsCount = taxCollectorsCount;
      this.taxCollectorLifePoints = taxCollectorLifePoints;
      this.taxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
      this.taxCollectorPods = taxCollectorPods;
      this.taxCollectorProspecting = taxCollectorProspecting;
      this.taxCollectorWisdom = taxCollectorWisdom;
      this.boostPoints = boostPoints;
      this.spellId = spellId;
      this.spellLevel = spellLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.maxTaxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxTaxCollectorsCount + ") on element maxTaxCollectorsCount.");
      writer.WriteByte((byte) this.maxTaxCollectorsCount);
      if (this.taxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorsCount + ") on element taxCollectorsCount.");
      writer.WriteByte((byte) this.taxCollectorsCount);
      if (this.taxCollectorLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorLifePoints + ") on element taxCollectorLifePoints.");
      writer.WriteVarShort((short) this.taxCollectorLifePoints);
      if (this.taxCollectorDamagesBonuses < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorDamagesBonuses + ") on element taxCollectorDamagesBonuses.");
      writer.WriteVarShort((short) this.taxCollectorDamagesBonuses);
      if (this.taxCollectorPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorPods + ") on element taxCollectorPods.");
      writer.WriteVarShort((short) this.taxCollectorPods);
      if (this.taxCollectorProspecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorProspecting + ") on element taxCollectorProspecting.");
      writer.WriteVarShort((short) this.taxCollectorProspecting);
      if (this.taxCollectorWisdom < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorWisdom + ") on element taxCollectorWisdom.");
      writer.WriteVarShort((short) this.taxCollectorWisdom);
      if (this.boostPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostPoints + ") on element boostPoints.");
      writer.WriteVarShort((short) this.boostPoints);
      writer.WriteShort((short) this.spellId.Count);
      for (int index = 0; index < this.spellId.Count; ++index)
      {
        if (this.spellId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.spellId[index] + ") on element 9 (starting at 1) of spellId.");
        writer.WriteVarShort((short) this.spellId[index]);
      }
      writer.WriteShort((short) this.spellLevel.Count);
      for (int index = 0; index < this.spellLevel.Count; ++index)
        writer.WriteShort((short) this.spellLevel[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.maxTaxCollectorsCount = (uint) reader.ReadByte();
      if (this.maxTaxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxTaxCollectorsCount + ") on element of GuildInfosUpgradeMessage.maxTaxCollectorsCount.");
      this.taxCollectorsCount = (uint) reader.ReadByte();
      if (this.taxCollectorsCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorsCount + ") on element of GuildInfosUpgradeMessage.taxCollectorsCount.");
      this.taxCollectorLifePoints = (uint) reader.ReadVarUhShort();
      if (this.taxCollectorLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorLifePoints + ") on element of GuildInfosUpgradeMessage.taxCollectorLifePoints.");
      this.taxCollectorDamagesBonuses = (uint) reader.ReadVarUhShort();
      if (this.taxCollectorDamagesBonuses < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorDamagesBonuses + ") on element of GuildInfosUpgradeMessage.taxCollectorDamagesBonuses.");
      this.taxCollectorPods = (uint) reader.ReadVarUhShort();
      if (this.taxCollectorPods < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorPods + ") on element of GuildInfosUpgradeMessage.taxCollectorPods.");
      this.taxCollectorProspecting = (uint) reader.ReadVarUhShort();
      if (this.taxCollectorProspecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorProspecting + ") on element of GuildInfosUpgradeMessage.taxCollectorProspecting.");
      this.taxCollectorWisdom = (uint) reader.ReadVarUhShort();
      if (this.taxCollectorWisdom < 0U)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorWisdom + ") on element of GuildInfosUpgradeMessage.taxCollectorWisdom.");
      this.boostPoints = (uint) reader.ReadVarUhShort();
      if (this.boostPoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostPoints + ") on element of GuildInfosUpgradeMessage.boostPoints.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of spellId.");
        this.spellId.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
        this.spellLevel.Add((int) reader.ReadShort());
    }
  }
}
