using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftCountModifiedMessage : NetworkMessage
  {
    public const uint Id = 6595;
    public int count;

    public override uint MessageId
    {
      get
      {
        return 6595;
      }
    }

    public ExchangeCraftCountModifiedMessage()
    {
    }

    public ExchangeCraftCountModifiedMessage(int count)
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
