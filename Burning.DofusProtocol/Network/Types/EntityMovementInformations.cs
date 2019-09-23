using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class EntityMovementInformations
  {
    public List<int> steps = new List<int>();
    public const uint Id = 63;
    public int id;

    public virtual uint TypeId
    {
      get
      {
        return 63;
      }
    }

    public EntityMovementInformations()
    {
    }

    public EntityMovementInformations(int id, List<int> steps)
    {
      this.id = id;
      this.steps = steps;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.id);
      writer.WriteShort((short) this.steps.Count);
      for (int index = 0; index < this.steps.Count; ++index)
        writer.WriteByte((byte) this.steps[index]);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadInt();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.steps.Add((int) reader.ReadByte());
    }
  }
}
