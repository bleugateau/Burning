using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameDataPaddockObjectRemoveMessage : NetworkMessage
  {
    public const uint Id = 5993;
    public uint cellId;

    public override uint MessageId
    {
      get
      {
        return 5993;
      }
    }

    public GameDataPaddockObjectRemoveMessage()
    {
    }

    public GameDataPaddockObjectRemoveMessage(uint cellId)
    {
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of GameDataPaddockObjectRemoveMessage.cellId.");
    }
  }
}
