using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatSmileyExtraPackListMessage : NetworkMessage
  {
    public List<uint> packIds = new List<uint>();
    public const uint Id = 6596;

    public override uint MessageId
    {
      get
      {
        return 6596;
      }
    }

    public ChatSmileyExtraPackListMessage()
    {
    }

    public ChatSmileyExtraPackListMessage(List<uint> packIds)
    {
      this.packIds = packIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.packIds.Count);
      for (int index = 0; index < this.packIds.Count; ++index)
      {
        if (this.packIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.packIds[index] + ") on element 1 (starting at 1) of packIds.");
        writer.WriteByte((byte) this.packIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of packIds.");
        this.packIds.Add(num2);
      }
    }
  }
}
