using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobCrafterDirectoryEntryPlayerInfo
  {
    public const uint Id = 194;
    public double playerId;
    public string playerName;
    public int alignmentSide;
    public int breed;
    public bool sex;
    public bool isInWorkshop;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public PlayerStatus status;

    public virtual uint TypeId
    {
      get
      {
        return 194;
      }
    }

    public JobCrafterDirectoryEntryPlayerInfo()
    {
    }

    public JobCrafterDirectoryEntryPlayerInfo(
      double playerId,
      string playerName,
      int alignmentSide,
      int breed,
      bool sex,
      bool isInWorkshop,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      PlayerStatus status)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.alignmentSide = alignmentSide;
      this.breed = breed;
      this.sex = sex;
      this.isInWorkshop = isInWorkshop;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.status = status;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      writer.WriteByte((byte) this.alignmentSide);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      writer.WriteBoolean(this.isInWorkshop);
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
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of JobCrafterDirectoryEntryPlayerInfo.playerId.");
      this.playerName = reader.ReadUTF();
      this.alignmentSide = (int) reader.ReadByte();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of JobCrafterDirectoryEntryPlayerInfo.breed.");
      this.sex = reader.ReadBoolean();
      this.isInWorkshop = reader.ReadBoolean();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of JobCrafterDirectoryEntryPlayerInfo.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of JobCrafterDirectoryEntryPlayerInfo.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of JobCrafterDirectoryEntryPlayerInfo.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of JobCrafterDirectoryEntryPlayerInfo.subAreaId.");
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
