using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
  {
    public const uint Id = 5945;
    public ObjectItemToSellInBid itemInfo;

    public override uint MessageId
    {
      get
      {
        return 5945;
      }
    }

    public ExchangeBidHouseItemAddOkMessage()
    {
    }

    public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
    {
      this.itemInfo = itemInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.itemInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.itemInfo = new ObjectItemToSellInBid();
      this.itemInfo.Deserialize(reader);
    }
  }
}
