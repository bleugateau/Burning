using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnReadyMessage : NetworkMessage
  {
    public const uint Id = 716;
    public bool isReady;

    public override uint MessageId
    {
      get
      {
        return 716;
      }
    }

    public GameFightTurnReadyMessage()
    {
    }

    public GameFightTurnReadyMessage(bool isReady)
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
