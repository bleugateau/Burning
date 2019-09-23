using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMembershipMessage : GuildJoinedMessage
  {
    public new const uint Id = 5835;

    public override uint MessageId
    {
      get
      {
        return 5835;
      }
    }

    public GuildMembershipMessage()
    {
    }

    public GuildMembershipMessage(GuildInformations guildInfo, uint memberRights)
      : base(guildInfo, memberRights)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
