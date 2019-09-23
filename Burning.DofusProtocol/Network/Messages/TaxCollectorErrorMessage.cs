using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorErrorMessage : NetworkMessage
  {
    public const uint Id = 5634;
    public int reason;

    public override uint MessageId
    {
      get
      {
        return 5634;
      }
    }

    public TaxCollectorErrorMessage()
    {
    }

    public TaxCollectorErrorMessage(int reason)
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
