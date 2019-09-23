using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
  {
    public List<uint> availableLegendaryIds = new List<uint>();
    public const uint Id = 6498;

    public override uint MessageId
    {
      get
      {
        return 6498;
      }
    }

    public TreasureHuntShowLegendaryUIMessage()
    {
    }

    public TreasureHuntShowLegendaryUIMessage(List<uint> availableLegendaryIds)
    {
      this.availableLegendaryIds = availableLegendaryIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.availableLegendaryIds.Count);
      for (int index = 0; index < this.availableLegendaryIds.Count; ++index)
      {
        if (this.availableLegendaryIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.availableLegendaryIds[index] + ") on element 1 (starting at 1) of availableLegendaryIds.");
        writer.WriteVarShort((short) this.availableLegendaryIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of availableLegendaryIds.");
        this.availableLegendaryIds.Add(num2);
      }
    }
  }
}
