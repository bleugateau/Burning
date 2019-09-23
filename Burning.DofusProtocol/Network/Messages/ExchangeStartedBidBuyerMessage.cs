using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedBidBuyerMessage : NetworkMessage
  {
    public const uint Id = 5904;
    public SellerBuyerDescriptor buyerDescriptor;

    public override uint MessageId
    {
      get
      {
        return 5904;
      }
    }

    public ExchangeStartedBidBuyerMessage()
    {
    }

    public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
    {
      this.buyerDescriptor = buyerDescriptor;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.buyerDescriptor.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.buyerDescriptor = new SellerBuyerDescriptor();
      this.buyerDescriptor.Deserialize(reader);
    }
  }
}
