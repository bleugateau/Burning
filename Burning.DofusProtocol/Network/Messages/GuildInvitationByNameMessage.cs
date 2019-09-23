using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInvitationByNameMessage : NetworkMessage
  {
    public const uint Id = 6115;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 6115;
      }
    }

    public GuildInvitationByNameMessage()
    {
    }

    public GuildInvitationByNameMessage(string name)
    {
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
    }
  }
}
