using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedMessage : NetworkMessage
  {
    public const uint Id = 5512;
    public int exchangeType;

    public override uint MessageId
    {
      get
      {
        return 5512;
      }
    }

    public ExchangeStartedMessage()
    {
    }

    public ExchangeStartedMessage(int exchangeType)
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
