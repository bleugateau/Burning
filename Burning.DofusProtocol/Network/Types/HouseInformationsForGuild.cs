using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseInformationsForGuild : HouseInformations
  {
    public List<int> skillListIds = new List<int>();
    public new const uint Id = 170;
    public uint instanceId;
    public bool secondHand;
    public string ownerName;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public uint guildshareParams;

    public override uint TypeId
    {
      get
      {
        return 170;
      }
    }

    public HouseInformationsForGuild()
    {
    }

    public HouseInformationsForGuild(
      uint houseId,
      uint modelId,
      uint instanceId,
      bool secondHand,
      string ownerName,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      List<int> skillListIds,
      uint guildshareParams)
      : base(houseId, modelId)
    {
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.ownerName = ownerName;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.skillListIds = skillListIds;
      this.guildshareParams = guildshareParams;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.secondHand);
      writer.WriteUTF(this.ownerName);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteShort((short) this.skillListIds.Count);
      for (int index = 0; index < this.skillListIds.Count; ++index)
        writer.WriteInt(this.skillListIds[index]);
      if (this.guildshareParams < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildshareParams + ") on element guildshareParams.");
      writer.WriteVarInt((int) this.guildshareParams);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseInformationsForGuild.instanceId.");
      this.secondHand = reader.ReadBoolean();
      this.ownerName = reader.ReadUTF();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of HouseInformationsForGuild.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of HouseInformationsForGuild.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of HouseInformationsForGuild.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of HouseInformationsForGuild.subAreaId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.skillListIds.Add(reader.ReadInt());
      this.guildshareParams = reader.ReadVarUhInt();
      if (this.guildshareParams < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildshareParams + ") on element of HouseInformationsForGuild.guildshareParams.");
    }
  }
}
