using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class AtlasPointsInformations
  {
    public List<MapCoordinatesExtended> coords = new List<MapCoordinatesExtended>();
    public const uint Id = 175;
    public uint type;

    public virtual uint TypeId
    {
      get
      {
        return 175;
      }
    }

    public AtlasPointsInformations()
    {
    }

    public AtlasPointsInformations(uint type, List<MapCoordinatesExtended> coords)
    {
      this.type = type;
      this.coords = coords;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      writer.WriteShort((short) this.coords.Count);
      for (int index = 0; index < this.coords.Count; ++index)
        this.coords[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of AtlasPointsInformations.type.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MapCoordinatesExtended coordinatesExtended = new MapCoordinatesExtended();
        coordinatesExtended.Deserialize(reader);
        this.coords.Add(coordinatesExtended);
      }
    }
  }
}
