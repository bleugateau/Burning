using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightReadyMessage : NetworkMessage
  {
    public const uint Id = 708;
    public bool isReady;

    public override uint MessageId
    {
      get
      {
        return 708;
      }
    }

    public GameFightReadyMessage()
    {
    }

    public GameFightReadyMessage(bool isReady)
    {
      this.isReady = isReady;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.isReady);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.isReady = reader.ReadBoolean();
    }
  }
}
