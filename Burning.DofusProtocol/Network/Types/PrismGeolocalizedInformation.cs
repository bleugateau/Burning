using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
  {
    public new const uint Id = 434;
    public int worldX;
    public int worldY;
    public double mapId;
    public PrismInformation prism;

    public override uint TypeId
    {
      get
      {
        return 434;
      }
    }

    public PrismGeolocalizedInformation()
    {
    }

    public PrismGeolocalizedInformation(
      uint subAreaId,
      uint allianceId,
      int worldX,
      int worldY,
      double mapId,
      PrismInformation prism)
      : base(subAreaId, allianceId)
    {
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.prism = prism;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteShort((short) this.prism.TypeId);
      this.prism.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PrismGeolocalizedInformation.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PrismGeolocalizedInformation.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of PrismGeolocalizedInformation.mapId.");
      this.prism = ProtocolTypeManager.GetInstance<PrismInformation>((uint) reader.ReadUShort());
      this.prism.Deserialize(reader);
    }
  }
}
