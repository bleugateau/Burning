using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionGuild : HumanOption
  {
    public new const uint Id = 409;
    public GuildInformations guildInformations;

    public override uint TypeId
    {
      get
      {
        return 409;
      }
    }

    public HumanOptionGuild()
    {
    }

    public HumanOptionGuild(GuildInformations guildInformations)
    {
      this.guildInformations = guildInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guildInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guildInformations = new GuildInformations();
      this.guildInformations.Deserialize(reader);
    }
  }
}
