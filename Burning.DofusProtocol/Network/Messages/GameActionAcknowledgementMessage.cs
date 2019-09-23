using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionAcknowledgementMessage : NetworkMessage
  {
    public const uint Id = 957;
    public bool valid;
    public int actionId;

    public override uint MessageId
    {
      get
      {
        return 957;
      }
    }

    public GameActionAcknowledgementMessage()
    {
    }

    public GameActionAcknowledgementMessage(bool valid, int actionId)
    {
      this.valid = valid;
      this.actionId = actionId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.valid);
      writer.WriteByte((byte) this.actionId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.valid = reader.ReadBoolean();
      this.actionId = (int) reader.ReadByte();
    }
  }
}
