using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseToSellListRequestMessage : NetworkMessage
  {
    public const uint Id = 6139;
    public uint pageIndex;

    public override uint MessageId
    {
      get
      {
        return 6139;
      }
    }

    public HouseToSellListRequestMessage()
    {
    }

    public HouseToSellListRequestMessage(uint pageIndex)
    {
      this.pageIndex = pageIndex;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element pageIndex.");
      writer.WriteVarShort((short) this.pageIndex);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.pageIndex = (uint) reader.ReadVarUhShort();
      if (this.pageIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.pageIndex + ") on element of HouseToSellListRequestMessage.pageIndex.");
    }
  }
}
