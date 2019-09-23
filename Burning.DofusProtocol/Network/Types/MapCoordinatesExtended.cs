using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MapCoordinatesExtended : MapCoordinatesAndId
  {
    public new const uint Id = 176;
    public uint subAreaId;

    public override uint TypeId
    {
      get
      {
        return 176;
      }
    }

    public MapCoordinatesExtended()
    {
    }

    public MapCoordinatesExtended(int worldX, int worldY, double mapId, uint subAreaId)
      : base(worldX, worldY, mapId)
    {
      this.subAreaId = subAreaId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of MapCoordinatesExtended.subAreaId.");
    }
  }
}
