using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
  {
    public List<uint> elementEventIds = new List<uint>();
    public new const uint Id = 6416;

    public override uint MessageId
    {
      get
      {
        return 6416;
      }
    }

    public GameContextRemoveMultipleElementsWithEventsMessage()
    {
    }

    public GameContextRemoveMultipleElementsWithEventsMessage(
      List<double> elementsIds,
      List<uint> elementEventIds)
      : base(elementsIds)
    {
      this.elementEventIds = elementEventIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.elementEventIds.Count);
      for (int index = 0; index < this.elementEventIds.Count; ++index)
      {
        if (this.elementEventIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.elementEventIds[index] + ") on element 1 (starting at 1) of elementEventIds.");
        writer.WriteByte((byte) this.elementEventIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of elementEventIds.");
        this.elementEventIds.Add(num2);
      }
    }
  }
}
