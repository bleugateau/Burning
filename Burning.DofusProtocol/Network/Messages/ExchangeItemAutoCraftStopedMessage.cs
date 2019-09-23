using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
  {
    public const uint Id = 5810;
    public int reason;

    public override uint MessageId
    {
      get
      {
        return 5810;
      }
    }

    public ExchangeItemAutoCraftStopedMessage()
    {
    }

    public ExchangeItemAutoCraftStopedMessage(int reason)
    {
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.reason = (int) reader.ReadByte();
    }
  }
}
