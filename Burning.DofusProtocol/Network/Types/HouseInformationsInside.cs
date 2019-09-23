using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseInformationsInside : HouseInformations
  {
    public new const uint Id = 218;
    public HouseInstanceInformations houseInfos;
    public int worldX;
    public int worldY;

    public override uint TypeId
    {
      get
      {
        return 218;
      }
    }

    public HouseInformationsInside()
    {
    }

    public HouseInformationsInside(
      uint houseId,
      uint modelId,
      HouseInstanceInformations houseInfos,
      int worldX,
      int worldY)
      : base(houseId, modelId)
    {
      this.houseInfos = houseInfos;
      this.worldX = worldX;
      this.worldY = worldY;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.houseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>((uint) reader.ReadUShort());
      this.houseInfos.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of HouseInformationsInside.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of HouseInformationsInside.worldY.");
    }
  }
}
