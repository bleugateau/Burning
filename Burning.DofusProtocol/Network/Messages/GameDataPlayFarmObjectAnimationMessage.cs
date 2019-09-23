using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
  {
    public List<uint> cellId = new List<uint>();
    public const uint Id = 6026;

    public override uint MessageId
    {
      get
      {
        return 6026;
      }
    }

    public GameDataPlayFarmObjectAnimationMessage()
    {
    }

    public GameDataPlayFarmObjectAnimationMessage(List<uint> cellId)
    {
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.cellId.Count);
      for (int index = 0; index < this.cellId.Count; ++index)
      {
        if (this.cellId[index] < 0U || this.cellId[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.cellId[index] + ") on element 1 (starting at 1) of cellId.");
        writer.WriteVarShort((short) this.cellId[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of cellId.");
        this.cellId.Add(num2);
      }
    }
  }
}
