using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkNpcShopMessage : NetworkMessage
  {
    public List<ObjectItemToSellInNpcShop> objectsInfos = new List<ObjectItemToSellInNpcShop>();
    public const uint Id = 5761;
    public double npcSellerId;
    public uint tokenId;

    public override uint MessageId
    {
      get
      {
        return 5761;
      }
    }

    public ExchangeStartOkNpcShopMessage()
    {
    }

    public ExchangeStartOkNpcShopMessage(
      double npcSellerId,
      uint tokenId,
      List<ObjectItemToSellInNpcShop> objectsInfos)
    {
      this.npcSellerId = npcSellerId;
      this.tokenId = tokenId;
      this.objectsInfos = objectsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.npcSellerId < -9.00719925474099E+15 || this.npcSellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcSellerId + ") on element npcSellerId.");
      writer.WriteDouble(this.npcSellerId);
      if (this.tokenId < 0U)
        throw new Exception("Forbidden value (" + (object) this.tokenId + ") on element tokenId.");
      writer.WriteVarShort((short) this.tokenId);
      writer.WriteShort((short) this.objectsInfos.Count);
      for (int index = 0; index < this.objectsInfos.Count; ++index)
        this.objectsInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.npcSellerId = reader.ReadDouble();
      if (this.npcSellerId < -9.00719925474099E+15 || this.npcSellerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcSellerId + ") on element of ExchangeStartOkNpcShopMessage.npcSellerId.");
      this.tokenId = (uint) reader.ReadVarUhShort();
      if (this.tokenId < 0U)
        throw new Exception("Forbidden value (" + (object) this.tokenId + ") on element of ExchangeStartOkNpcShopMessage.tokenId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemToSellInNpcShop itemToSellInNpcShop = new ObjectItemToSellInNpcShop();
        itemToSellInNpcShop.Deserialize(reader);
        this.objectsInfos.Add(itemToSellInNpcShop);
      }
    }
  }
}
