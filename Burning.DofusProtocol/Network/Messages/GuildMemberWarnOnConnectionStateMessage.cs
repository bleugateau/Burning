using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMemberWarnOnConnectionStateMessage : NetworkMessage
  {
    public const uint Id = 6160;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6160;
      }
    }

    public GuildMemberWarnOnConnectionStateMessage()
    {
    }

    public GuildMemberWarnOnConnectionStateMessage(bool enable)
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
