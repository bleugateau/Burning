using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class AllianceInsiderPrismInformation : PrismInformation
  {
    public List<ObjectItem> modulesObjects = new List<ObjectItem>();
    public new const uint Id = 431;
    public uint lastTimeSlotModificationDate;
    public uint lastTimeSlotModificationAuthorGuildId;
    public double lastTimeSlotModificationAuthorId;
    public string lastTimeSlotModificationAuthorName;

    public override uint TypeId
    {
      get
      {
        return 431;
      }
    }

    public AllianceInsiderPrismInformation()
    {
    }

    public AllianceInsiderPrismInformation(
      uint typeId,
      uint state,
      uint nextVulnerabilityDate,
      uint placementDate,
      uint rewardTokenCount,
      uint lastTimeSlotModificationDate,
      uint lastTimeSlotModificationAuthorGuildId,
      double lastTimeSlotModificationAuthorId,
      string lastTimeSlotModificationAuthorName,
      List<ObjectItem> modulesObjects)
      : base(typeId, state, nextVulnerabilityDate, placementDate, rewardTokenCount)
    {
      this.lastTimeSlotModificationDate = lastTimeSlotModificationDate;
      this.lastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
      this.lastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
      this.lastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
      this.modulesObjects = modulesObjects;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.lastTimeSlotModificationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationDate + ") on element lastTimeSlotModificationDate.");
      writer.WriteInt((int) this.lastTimeSlotModificationDate);
      if (this.lastTimeSlotModificationAuthorGuildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationAuthorGuildId + ") on element lastTimeSlotModificationAuthorGuildId.");
      writer.WriteVarInt((int) this.lastTimeSlotModificationAuthorGuildId);
      if (this.lastTimeSlotModificationAuthorId < 0.0 || this.lastTimeSlotModificationAuthorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationAuthorId + ") on element lastTimeSlotModificationAuthorId.");
      writer.WriteVarLong((long) this.lastTimeSlotModificationAuthorId);
      writer.WriteUTF(this.lastTimeSlotModificationAuthorName);
      writer.WriteShort((short) this.modulesObjects.Count);
      for (int index = 0; index < this.modulesObjects.Count; ++index)
        this.modulesObjects[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.lastTimeSlotModificationDate = (uint) reader.ReadInt();
      if (this.lastTimeSlotModificationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationDate + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationDate.");
      this.lastTimeSlotModificationAuthorGuildId = reader.ReadVarUhInt();
      if (this.lastTimeSlotModificationAuthorGuildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationAuthorGuildId + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationAuthorGuildId.");
      this.lastTimeSlotModificationAuthorId = (double) reader.ReadVarUhLong();
      if (this.lastTimeSlotModificationAuthorId < 0.0 || this.lastTimeSlotModificationAuthorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.lastTimeSlotModificationAuthorId + ") on element of AllianceInsiderPrismInformation.lastTimeSlotModificationAuthorId.");
      this.lastTimeSlotModificationAuthorName = reader.ReadUTF();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.modulesObjects.Add(objectItem);
      }
    }
  }
}
