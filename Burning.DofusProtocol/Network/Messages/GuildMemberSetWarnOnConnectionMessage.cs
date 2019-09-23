using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMemberSetWarnOnConnectionMessage : NetworkMessage
  {
    public const uint Id = 6159;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6159;
      }
    }

    public GuildMemberSetWarnOnConnectionMessage()
    {
    }

    public GuildMemberSetWarnOnConnectionMessage(bool enable)
    {
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.enable);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.enable = reader.ReadBoolean();
    }
  }
}
