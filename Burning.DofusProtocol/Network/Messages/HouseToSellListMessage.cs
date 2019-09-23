using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseToSellListMessage : NetworkMessage
  {
    public List<HouseInformationsForSell> houseList = new List<HouseInformationsForSell>();
    public const uint Id = 6140;
    public uint pageIndex;
    public uint totalPage;

    public override uint MessageId
    {
      get
      {
        return 6140;
      }
    }

    public HouseToSellListMessage()
    {
    }

    public HouseToSellListMessage(
      uint pageIndex,
      uint totalPage,
      List<HouseInformationsForSell> houseList)
    {
      this.pageIndex = pageIndex;
      this.totalPage = totalPage;
      this.houseList = houseList;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element pageIndex.");
      writer.WriteVarShort((short) this.pageIndex);
      if (this.totalPage < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalPage + ") on element totalPage.");
      writer.WriteVarShort((short) this.totalPage);
      writer.WriteShort((short) this.houseList.Count);
      for (int index = 0; index < this.houseList.Count; ++index)
        this.houseList[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.pageIndex = (uint) reader.ReadVarUhShort();
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element of HouseToSellListMessage.pageIndex.");
      this.totalPage = (uint) reader.ReadVarUhShort();
      if (this.totalPage < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalPage + ") on element of HouseToSellListMessage.totalPage.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        HouseInformationsForSell informationsForSell = new HouseInformationsForSell();
        informationsForSell.Deserialize(reader);
        this.houseList.Add(informationsForSell);
      }
    }
  }
}
