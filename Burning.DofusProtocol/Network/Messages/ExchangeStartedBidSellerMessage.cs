using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedBidSellerMessage : NetworkMessage
  {
    public List<ObjectItemToSellInBid> objectsInfos = new List<ObjectItemToSellInBid>();
    public const uint Id = 5905;
    public SellerBuyerDescriptor sellerDescriptor;

    public override uint MessageId
    {
      get
      {
        return 5905;
      }
    }

    public ExchangeStartedBidSellerMessage()
    {
    }

    public ExchangeStartedBidSellerMessage(
      SellerBuyerDescriptor sellerDescriptor,
      List<ObjectItemToSellInBid> objectsInfos)
    {
      this.sellerDescriptor = sellerDescriptor;
      this.objectsInfos = objectsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.sellerDescriptor.Serialize(writer);
      writer.WriteShort((short) this.objectsInfos.Count);
      for (int index = 0; index < this.objectsInfos.Count; ++index)
        this.objectsInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sellerDescriptor = new SellerBuyerDescriptor();
      this.sellerDescriptor.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemToSellInBid objectItemToSellInBid = new ObjectItemToSellInBid();
        objectItemToSellInBid.Deserialize(reader);
        this.objectsInfos.Add(objectItemToSellInBid);
      }
    }
  }
}
