using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class DareCriteria
  {
    public List<int> @params = new List<int>();
    public const uint Id = 501;
    public uint type;

    public virtual uint TypeId
    {
      get
      {
        return 501;
      }
    }

    public DareCriteria()
    {
    }

    public DareCriteria(uint type, List<int> @params)
    {
      this.type = type;
      this.@params = @params;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      writer.WriteShort((short) this.@params.Count);
      for (int index = 0; index < this.@params.Count; ++index)
        writer.WriteInt(this.@params[index]);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of DareCriteria.type.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.@params.Add(reader.ReadInt());
    }
  }
}
