using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeRequestedMessage : NetworkMessage
  {
    public const uint Id = 5522;
    public int exchangeType;

    public override uint MessageId
    {
      get
      {
        return 5522;
      }
    }

    public ExchangeRequestedMessage()
    {
    }

    public ExchangeRequestedMessage(int exchangeType)
    {
      this.exchangeType = exchangeType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.exchangeType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.exchangeType = (int) reader.ReadByte();
    }
  }
}
