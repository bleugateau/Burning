using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeErrorMessage : NetworkMessage
  {
    public const uint Id = 5513;
    public int errorType;

    public override uint MessageId
    {
      get
      {
        return 5513;
      }
    }

    public ExchangeErrorMessage()
    {
    }

    public ExchangeErrorMessage(int errorType)
    {
      this.errorType = errorType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.errorType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.errorType = (int) reader.ReadByte();
    }
  }
}
