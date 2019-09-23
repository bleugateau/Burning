using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockToSellListMessage : NetworkMessage
  {
    public List<PaddockInformationsForSell> paddockList = new List<PaddockInformationsForSell>();
    public const uint Id = 6138;
    public uint pageIndex;
    public uint totalPage;

    public override uint MessageId
    {
      get
      {
        return 6138;
      }
    }

    public PaddockToSellListMessage()
    {
    }

    public PaddockToSellListMessage(
      uint pageIndex,
      uint totalPage,
      List<PaddockInformationsForSell> paddockList)
    {
      this.pageIndex = pageIndex;
      this.totalPage = totalPage;
      this.paddockList = paddockList;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element pageIndex.");
      writer.WriteVarShort((short) this.pageIndex);
      if (this.totalPage < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalPage + ") on element totalPage.");
      writer.WriteVarShort((short) this.totalPage);
      writer.WriteShort((short) this.paddockList.Count);
      for (int index = 0; index < this.paddockList.Count; ++index)
        this.paddockList[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.pageIndex = (uint) reader.ReadVarUhShort();
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element of PaddockToSellListMessage.pageIndex.");
      this.totalPage = (uint) reader.ReadVarUhShort();
      if (this.totalPage < 0U)
        throw new Exception("Forbidden value (" + (object) this.totalPage + ") on element of PaddockToSellListMessage.totalPage.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PaddockInformationsForSell informationsForSell = new PaddockInformationsForSell();
        informationsForSell.Deserialize(reader);
        this.paddockList.Add(informationsForSell);
      }
    }
  }
}
