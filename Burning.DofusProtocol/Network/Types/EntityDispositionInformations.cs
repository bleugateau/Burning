using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class EntityDispositionInformations
  {
    public const uint Id = 60;
    public int cellId;
    public uint direction;

    public virtual uint TypeId
    {
      get
      {
        return 60;
      }
    }

    public EntityDispositionInformations()
    {
    }

    public EntityDispositionInformations(int cellId, uint direction)
    {
      this.cellId = cellId;
      this.direction = direction;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteShort((short) this.cellId);
      writer.WriteByte((byte) this.direction);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.cellId = (int) reader.ReadShort();
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of EntityDispositionInformations.cellId.");
      this.direction = (uint) reader.ReadByte();
      if (this.direction < 0U)
        throw new Exception("Forbidden value (" + (object) this.direction + ") on element of EntityDispositionInformations.direction.");
    }
  }
}
