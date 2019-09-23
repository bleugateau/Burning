using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftCountRequestMessage : NetworkMessage
  {
    public const uint Id = 6597;
    public int count;

    public override uint MessageId
    {
      get
      {
        return 6597;
      }
    }

    public ExchangeCraftCountRequestMessage()
    {
    }

    public ExchangeCraftCountRequestMessage(int count)
    {
      this.count = count;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.count);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.count = reader.ReadVarInt();
    }
  }
}
