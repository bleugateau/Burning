using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AccountHouseInformations : HouseInformations
  {
    public new const uint Id = 390;
    public HouseInstanceInformations houseInfos;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;

    public override uint TypeId
    {
      get
      {
        return 390;
      }
    }

    public AccountHouseInformations()
    {
    }

    public AccountHouseInformations(
      uint houseId,
      uint modelId,
      HouseInstanceInformations houseInfos,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId)
      : base(houseId, modelId)
    {
      this.houseInfos = houseInfos;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.houseInfos.TypeId);
      this.houseInfos.Serialize(writer);
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

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.houseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>((uint) reader.ReadUShort());
      this.houseInfos.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of AccountHouseInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of AccountHouseInformations.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of AccountHouseInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of AccountHouseInformations.subAreaId.");
    }
  }
}
