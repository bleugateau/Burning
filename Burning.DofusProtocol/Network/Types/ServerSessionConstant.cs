using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ServerSessionConstant
  {
    public const uint Id = 430;
    public uint id;

    public virtual uint TypeId
    {
      get
      {
        return 430;
      }
    }

    public ServerSessionConstant()
    {
    }

    public ServerSessionConstant(uint id)
    {
      this.id = id;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of ServerSessionConstant.id.");
    }
  }
}
