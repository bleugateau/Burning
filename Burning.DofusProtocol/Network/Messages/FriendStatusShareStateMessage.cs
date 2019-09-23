using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendStatusShareStateMessage : NetworkMessage
  {
    public const uint Id = 6823;
    public bool share;

    public override uint MessageId
    {
      get
      {
        return 6823;
      }
    }

    public FriendStatusShareStateMessage()
    {
    }

    public FriendStatusShareStateMessage(bool share)
    {
      this.share = share;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.share);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.share = reader.ReadBoolean();
    }
  }
}
