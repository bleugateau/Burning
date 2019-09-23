using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendWarnOnConnectionStateMessage : NetworkMessage
  {
    public const uint Id = 5630;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 5630;
      }
    }

    public FriendWarnOnConnectionStateMessage()
    {
    }

    public FriendWarnOnConnectionStateMessage(bool enable)
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
