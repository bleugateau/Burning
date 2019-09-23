using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InvalidPresetsMessage : NetworkMessage
  {
    public List<uint> presetIds = new List<uint>();
    public const uint Id = 6839;

    public override uint MessageId
    {
      get
      {
        return 6839;
      }
    }

    public InvalidPresetsMessage()
    {
    }

    public InvalidPresetsMessage(List<uint> presetIds)
    {
      this.presetIds = presetIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetIds.Count);
      for (int index = 0; index < this.presetIds.Count; ++index)
      {
        if (this.presetIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.presetIds[index] + ") on element 1 (starting at 1) of presetIds.");
        writer.WriteShort((short) this.presetIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of presetIds.");
        this.presetIds.Add(num2);
      }
    }
  }
}
