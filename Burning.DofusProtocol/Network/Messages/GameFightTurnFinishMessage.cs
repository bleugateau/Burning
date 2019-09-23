using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnFinishMessage : NetworkMessage
  {
    public const uint Id = 718;
    public bool isAfk;

    public override uint MessageId
    {
      get
      {
        return 718;
      }
    }

    public GameFightTurnFinishMessage()
    {
    }

    public GameFightTurnFinishMessage(bool isAfk)
    {
      this.isAfk = isAfk;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.isAfk);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.isAfk = reader.ReadBoolean();
    }
  }
}
