using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkHumanVendorMessage : NetworkMessage
  {
    public List<ObjectItemToSellInHumanVendorShop> objectsInfos = new List<ObjectItemToSellInHumanVendorShop>();
    public const uint Id = 5767;
    public double sellerId;

    public override uint MessageId
    {
      get
      {
        return 5767;
      }
    }

    public ExchangeStartOkHumanVendorMessage()
    {
    }

    public ExchangeStartOkHumanVendorMessage(
      double sellerId,
      List<ObjectItemToSellInHumanVendorShop> objectsInfos)
    {
      this.sellerId = sellerId;
      this.objectsInfos = objectsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.sellerId < -9.00719925474099E+15 || this.sellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sellerId + ") on element sellerId.");
      writer.WriteDouble(this.sellerId);
      writer.WriteShort((short) this.objectsInfos.Count);
      for (int index = 0; index < this.objectsInfos.Count; ++index)
        this.objectsInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sellerId = reader.ReadDouble();
      if (this.sellerId < -9.00719925474099E+15 || this.sellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sellerId + ") on element of ExchangeStartOkHumanVendorMessage.sellerId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemToSellInHumanVendorShop inHumanVendorShop = new ObjectItemToSellInHumanVendorShop();
        inHumanVendorShop.Deserialize(reader);
        this.objectsInfos.Add(inHumanVendorShop);
      }
    }
  }
}
