using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultFighterListEntry : FightResultListEntry
  {
    public new const uint Id = 189;
    public double id;
    public bool alive;

    public override uint TypeId
    {
      get
      {
        return 189;
      }
    }

    public FightResultFighterListEntry()
    {
    }

    public FightResultFighterListEntry(
      uint outcome,
      uint wave,
      FightLoot rewards,
      double id,
      bool alive)
      : base(outcome, wave, rewards)
    {
      this.id = id;
      this.alive = alive;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      writer.WriteBoolean(this.alive);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of FightResultFighterListEntry.id.");
      this.alive = reader.ReadBoolean();
    }
  }
}
