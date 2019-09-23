using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffect
  {
    public const uint Id = 76;
    public uint actionId;

    public virtual uint TypeId
    {
      get
      {
        return 76;
      }
    }

    public ObjectEffect()
    {
    }

    public ObjectEffect(uint actionId)
    {
      this.actionId = actionId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteVarShort((short) this.actionId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.actionId = (uint) reader.ReadVarUhShort();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of ObjectEffect.actionId.");
    }
  }
}
