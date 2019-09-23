using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockMoveItemRequestMessage : NetworkMessage
  {
    public const uint Id = 6052;
    public uint oldCellId;
    public uint newCellId;

    public override uint MessageId
    {
      get
      {
        return 6052;
      }
    }

    public PaddockMoveItemRequestMessage()
    {
    }

    public PaddockMoveItemRequestMessage(uint oldCellId, uint newCellId)
    {
      this.oldCellId = oldCellId;
      this.newCellId = newCellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.oldCellId < 0U || this.oldCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.oldCellId + ") on element oldCellId.");
      writer.WriteVarShort((short) this.oldCellId);
      if (this.newCellId < 0U || this.newCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.newCellId + ") on element newCellId.");
      writer.WriteVarShort((short) this.newCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.oldCellId = (uint) reader.ReadVarUhShort();
      if (this.oldCellId < 0U || this.oldCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.oldCellId + ") on element of PaddockMoveItemRequestMessage.oldCellId.");
      this.newCellId = (uint) reader.ReadVarUhShort();
      if (this.newCellId < 0U || this.newCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.newCellId + ") on element of PaddockMoveItemRequestMessage.newCellId.");
    }
  }
}
