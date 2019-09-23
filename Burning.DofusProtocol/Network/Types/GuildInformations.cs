using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildInformations : BasicGuildInformations
  {
    public new const uint Id = 127;
    public GuildEmblem guildEmblem;

    public override uint TypeId
    {
      get
      {
        return (uint) sbyte.MaxValue;
      }
    }

    public GuildInformations()
    {
    }

    public GuildInformations(
      uint guildId,
      string guildName,
      uint guildLevel,
      GuildEmblem guildEmblem)
      : base(guildId, guildName, guildLevel)
    {
      this.guildEmblem = guildEmblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guildEmblem = new GuildEmblem();
      this.guildEmblem.Deserialize(reader);
    }
  }
}
