using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultMutantListEntry : FightResultFighterListEntry
  {
    public new const uint Id = 216;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 216;
      }
    }

    public FightResultMutantListEntry()
    {
    }

    public FightResultMutantListEntry(
      uint outcome,
      uint wave,
      FightLoot rewards,
      double id,
      bool alive,
      uint level)
      : base(outcome, wave, rewards, id, alive)
    {
      this.level = level;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightResultMutantListEntry.level.");
    }
  }
}
