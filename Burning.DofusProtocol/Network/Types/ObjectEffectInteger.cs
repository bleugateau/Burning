using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectInteger : ObjectEffect
  {
    public new const uint Id = 70;
    public uint value;

    public override uint TypeId
    {
      get
      {
        return 70;
      }
    }

    public ObjectEffectInteger()
    {
    }

    public ObjectEffectInteger(uint actionId, uint value)
      : base(actionId)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.value < 0U)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element value.");
      writer.WriteVarInt((int) this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = reader.ReadVarUhInt();
      if (this.value < 0U)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element of ObjectEffectInteger.value.");
    }
  }
}
