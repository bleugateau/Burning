using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInformationsMemberUpdateMessage : NetworkMessage
  {
    public const uint Id = 5597;
    public GuildMember member;

    public override uint MessageId
    {
      get
      {
        return 5597;
      }
    }

    public GuildInformationsMemberUpdateMessage()
    {
    }

    public GuildInformationsMemberUpdateMessage(GuildMember member)
    {
      this.member = member;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.member.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.member = new GuildMember();
      this.member.Deserialize(reader);
    }
  }
}
