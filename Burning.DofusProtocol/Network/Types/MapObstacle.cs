using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MapObstacle
  {
    public const uint Id = 200;
    public uint obstacleCellId;
    public uint state;

    public virtual uint TypeId
    {
      get
      {
        return 200;
      }
    }

    public MapObstacle()
    {
    }

    public MapObstacle(uint obstacleCellId, uint state)
    {
      this.obstacleCellId = obstacleCellId;
      this.state = state;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.obstacleCellId < 0U || this.obstacleCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.obstacleCellId + ") on element obstacleCellId.");
      writer.WriteVarShort((short) this.obstacleCellId);
      writer.WriteByte((byte) this.state);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.obstacleCellId = (uint) reader.ReadVarUhShort();
      if (this.obstacleCellId < 0U || this.obstacleCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.obstacleCellId + ") on element of MapObstacle.obstacleCellId.");
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of MapObstacle.state.");
    }
  }
}
