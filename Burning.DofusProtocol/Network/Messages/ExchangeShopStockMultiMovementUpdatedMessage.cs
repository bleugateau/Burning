using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
  {
    public List<ObjectItemToSell> objectInfoList = new List<ObjectItemToSell>();
    public const uint Id = 6038;

    public override uint MessageId
    {
      get
      {
        return 6038;
      }
    }

    public ExchangeShopStockMultiMovementUpdatedMessage()
    {
    }

    public ExchangeShopStockMultiMovementUpdatedMessage(List<ObjectItemToSell> objectInfoList)
    {
      this.objectInfoList = objectInfoList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectInfoList.Count);
      for (int index = 0; index < this.objectInfoList.Count; ++index)
        this.objectInfoList[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemToSell objectItemToSell = new ObjectItemToSell();
        objectItemToSell.Deserialize(reader);
        this.objectInfoList.Add(objectItemToSell);
      }
    }
  }
}
