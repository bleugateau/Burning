using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
  {
    public new const uint Id = 84;
    public uint level;
    public BasicGuildInformations guildInfo;
    public int experienceForGuild;

    public override uint TypeId
    {
      get
      {
        return 84;
      }
    }

    public FightResultTaxCollectorListEntry()
    {
    }

    public FightResultTaxCollectorListEntry(
      uint outcome,
      uint wave,
      FightLoot rewards,
      double id,
      bool alive,
      uint level,
      BasicGuildInformations guildInfo,
      int experienceForGuild)
      : base(outcome, wave, rewards, id, alive)
    {
      this.level = level;
      this.guildInfo = guildInfo;
      this.experienceForGuild = experienceForGuild;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
      this.guildInfo.Serialize(writer);
      writer.WriteInt(this.experienceForGuild);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadByte();
      if (this.level < 1U || this.level > 200U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightResultTaxCollectorListEntry.level.");
      this.guildInfo = new BasicGuildInformations();
      this.guildInfo.Deserialize(reader);
      this.experienceForGuild = reader.ReadInt();
    }
  }
}
