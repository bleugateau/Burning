using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectMinMax : ObjectEffect
  {
    public new const uint Id = 82;
    public uint min;
    public uint max;

    public override uint TypeId
    {
      get
      {
        return 82;
      }
    }

    public ObjectEffectMinMax()
    {
    }

    public ObjectEffectMinMax(uint actionId, uint min, uint max)
      : base(actionId)
    {
      this.min = min;
      this.max = max;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.min < 0U)
        throw new Exception("Forbidden value (" + (object) this.min + ") on element min.");
      writer.WriteVarInt((int) this.min);
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element max.");
      writer.WriteVarInt((int) this.max);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.min = reader.ReadVarUhInt();
      if (this.min < 0U)
        throw new Exception("Forbidden value (" + (object) this.min + ") on element of ObjectEffectMinMax.min.");
      this.max = reader.ReadVarUhInt();
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element of ObjectEffectMinMax.max.");
    }
  }
}
