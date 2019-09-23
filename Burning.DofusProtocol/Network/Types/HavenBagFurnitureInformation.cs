using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HavenBagFurnitureInformation
  {
    public const uint Id = 498;
    public uint cellId;
    public int funitureId;
    public uint orientation;

    public virtual uint TypeId
    {
      get
      {
        return 498;
      }
    }

    public HavenBagFurnitureInformation()
    {
    }

    public HavenBagFurnitureInformation(uint cellId, int funitureId, uint orientation)
    {
      this.cellId = cellId;
      this.funitureId = funitureId;
      this.orientation = orientation;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.cellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
      writer.WriteInt(this.funitureId);
      if (this.orientation < 0U)
        throw new Exception("Forbidden value (" + (object) this.orientation + ") on element orientation.");
      writer.WriteByte((byte) this.orientation);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of HavenBagFurnitureInformation.cellId.");
      this.funitureId = reader.ReadInt();
      this.orientation = (uint) reader.ReadByte();
      if (this.orientation < 0U)
        throw new Exception("Forbidden value (" + (object) this.orientation + ") on element of HavenBagFurnitureInformation.orientation.");
    }
  }
}
