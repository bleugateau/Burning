using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
  {
    public List<uint> objectIdList = new List<uint>();
    public const uint Id = 6037;

    public override uint MessageId
    {
      get
      {
        return 6037;
      }
    }

    public ExchangeShopStockMultiMovementRemovedMessage()
    {
    }

    public ExchangeShopStockMultiMovementRemovedMessage(List<uint> objectIdList)
    {
      this.objectIdList = objectIdList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectIdList.Count);
      for (int index = 0; index < this.objectIdList.Count; ++index)
      {
        if (this.objectIdList[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.objectIdList[index] + ") on element 1 (starting at 1) of objectIdList.");
        writer.WriteVarInt((int) this.objectIdList[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of objectIdList.");
        this.objectIdList.Add(num2);
      }
    }
  }
}
