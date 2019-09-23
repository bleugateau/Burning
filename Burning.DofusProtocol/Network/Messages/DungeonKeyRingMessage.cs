using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonKeyRingMessage : NetworkMessage
  {
    public List<uint> availables = new List<uint>();
    public List<uint> unavailables = new List<uint>();
    public const uint Id = 6299;

    public override uint MessageId
    {
      get
      {
        return 6299;
      }
    }

    public DungeonKeyRingMessage()
    {
    }

    public DungeonKeyRingMessage(List<uint> availables, List<uint> unavailables)
    {
      this.availables = availables;
      this.unavailables = unavailables;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.availables.Count);
      for (int index = 0; index < this.availables.Count; ++index)
      {
        if (this.availables[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.availables[index] + ") on element 1 (starting at 1) of availables.");
        writer.WriteVarShort((short) this.availables[index]);
      }
      writer.WriteShort((short) this.unavailables.Count);
      for (int index = 0; index < this.unavailables.Count; ++index)
      {
        if (this.unavailables[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.unavailables[index] + ") on element 2 (starting at 1) of unavailables.");
        writer.WriteVarShort((short) this.unavailables[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of availables.");
        this.availables.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of unavailables.");
        this.unavailables.Add(num2);
      }
    }
  }
}
