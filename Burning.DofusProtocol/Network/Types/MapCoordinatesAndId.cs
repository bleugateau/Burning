using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MapCoordinatesAndId : MapCoordinates
  {
    public new const uint Id = 392;
    public double mapId;

    public override uint TypeId
    {
      get
      {
        return 392;
      }
    }

    public MapCoordinatesAndId()
    {
    }

    public MapCoordinatesAndId(int worldX, int worldY, double mapId)
      : base(worldX, worldY)
    {
      this.mapId = mapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of MapCoordinatesAndId.mapId.");
    }
  }
}
