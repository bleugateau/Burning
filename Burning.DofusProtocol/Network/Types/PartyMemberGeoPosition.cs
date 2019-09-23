using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyMemberGeoPosition
  {
    public const uint Id = 378;
    public uint memberId;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;

    public virtual uint TypeId
    {
      get
      {
        return 378;
      }
    }

    public PartyMemberGeoPosition()
    {
    }

    public PartyMemberGeoPosition(
      uint memberId,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId)
    {
      this.memberId = memberId;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.memberId < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteInt((int) this.memberId);
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
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.memberId = (uint) reader.ReadInt();
      if (this.memberId < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of PartyMemberGeoPosition.memberId.");
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PartyMemberGeoPosition.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PartyMemberGeoPosition.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of PartyMemberGeoPosition.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PartyMemberGeoPosition.subAreaId.");
    }
  }
}
