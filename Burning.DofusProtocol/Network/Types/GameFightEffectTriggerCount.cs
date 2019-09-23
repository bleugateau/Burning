using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightEffectTriggerCount
  {
    public const uint Id = 569;
    public uint effectId;
    public double targetId;
    public uint count;

    public virtual uint TypeId
    {
      get
      {
        return 569;
      }
    }

    public GameFightEffectTriggerCount()
    {
    }

    public GameFightEffectTriggerCount(uint effectId, double targetId, uint count)
    {
      this.effectId = effectId;
      this.targetId = targetId;
      this.count = count;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.effectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.effectId + ") on element effectId.");
      writer.WriteVarInt((int) this.effectId);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.count < 0U)
        throw new Exception("Forbidden value (" + (object) this.count + ") on element count.");
      writer.WriteByte((byte) this.count);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.effectId = reader.ReadVarUhInt();
      if (this.effectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.effectId + ") on element of GameFightEffectTriggerCount.effectId.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameFightEffectTriggerCount.targetId.");
      this.count = (uint) reader.ReadByte();
      if (this.count < 0U)
        throw new Exception("Forbidden value (" + (object) this.count + ") on element of GameFightEffectTriggerCount.count.");
    }
  }
}
