using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
  {
    public const uint Id = 5946;
    public int sellerId;

    public override uint MessageId
    {
      get
      {
        return 5946;
      }
    }

    public ExchangeBidHouseItemRemoveOkMessage()
    {
    }

    public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
    {
      this.sellerId = sellerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.sellerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sellerId = reader.ReadInt();
    }
  }
}
