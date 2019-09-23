using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextRemoveMultipleElementsMessage : NetworkMessage
  {
    public List<double> elementsIds = new List<double>();
    public const uint Id = 252;

    public override uint MessageId
    {
      get
      {
        return 252;
      }
    }

    public GameContextRemoveMultipleElementsMessage()
    {
    }

    public GameContextRemoveMultipleElementsMessage(List<double> elementsIds)
    {
      this.elementsIds = elementsIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.elementsIds.Count);
      for (int index = 0; index < this.elementsIds.Count; ++index)
      {
        if (this.elementsIds[index] < -9.00719925474099E+15 || this.elementsIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.elementsIds[index] + ") on element 1 (starting at 1) of elementsIds.");
        writer.WriteDouble(this.elementsIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of elementsIds.");
        this.elementsIds.Add(num2);
      }
    }
  }
}
