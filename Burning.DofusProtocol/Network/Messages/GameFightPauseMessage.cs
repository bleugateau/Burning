using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightPauseMessage : NetworkMessage
  {
    public const uint Id = 6754;
    public bool isPaused;

    public override uint MessageId
    {
      get
      {
        return 6754;
      }
    }

    public GameFightPauseMessage()
    {
    }

    public GameFightPauseMessage(bool isPaused)
    {
      this.isPaused = isPaused;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.isPaused);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.isPaused = reader.ReadBoolean();
    }
  }
}
