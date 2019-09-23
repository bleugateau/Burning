using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MapCoordinates
  {
    public const uint Id = 174;
    public int worldX;
    public int worldY;

    public virtual uint TypeId
    {
      get
      {
        return 174;
      }
    }

    public MapCoordinates()
    {
    }

    public MapCoordinates(int worldX, int worldY)
    {
      this.worldX = worldX;
      this.worldY = worldY;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of MapCoordinates.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of MapCoordinates.worldY.");
    }
  }
}
