using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EmoteListMessage : NetworkMessage
  {
    public List<uint> emoteIds = new List<uint>();
    public const uint Id = 5689;

    public override uint MessageId
    {
      get
      {
        return 5689;
      }
    }

    public EmoteListMessage()
    {
    }

    public EmoteListMessage(List<uint> emoteIds)
    {
      this.emoteIds = emoteIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.emoteIds.Count);
      for (int index = 0; index < this.emoteIds.Count; ++index)
      {
        if (this.emoteIds[index] < 0U || this.emoteIds[index] > (uint) byte.MaxValue)
          throw new Exception("Forbidden value (" + (object) this.emoteIds[index] + ") on element 1 (starting at 1) of emoteIds.");
        writer.WriteByte((byte) this.emoteIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U || num2 > (uint) byte.MaxValue)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of emoteIds.");
        this.emoteIds.Add(num2);
      }
    }
  }
}
