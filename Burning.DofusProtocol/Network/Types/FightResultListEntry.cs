using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultListEntry
  {
    public const uint Id = 16;
    public uint outcome;
    public uint wave;
    public FightLoot rewards;

    public virtual uint TypeId
    {
      get
      {
        return 16;
      }
    }

    public FightResultListEntry()
    {
    }

    public FightResultListEntry(uint outcome, uint wave, FightLoot rewards)
    {
      this.outcome = outcome;
      this.wave = wave;
      this.rewards = rewards;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteVarShort((short) this.outcome);
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element wave.");
      writer.WriteByte((byte) this.wave);
      this.rewards.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.outcome = (uint) reader.ReadVarUhShort();
      if (this.outcome < 0U)
        throw new Exception("Forbidden value (" + (object) this.outcome + ") on element of FightResultListEntry.outcome.");
      this.wave = (uint) reader.ReadByte();
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element of FightResultListEntry.wave.");
      this.rewards = new FightLoot();
      this.rewards.Deserialize(reader);
    }
  }
}
