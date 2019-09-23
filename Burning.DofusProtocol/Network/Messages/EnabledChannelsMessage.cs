using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EnabledChannelsMessage : NetworkMessage
  {
    public List<uint> channels = new List<uint>();
    public List<uint> disallowed = new List<uint>();
    public const uint Id = 892;

    public override uint MessageId
    {
      get
      {
        return 892;
      }
    }

    public EnabledChannelsMessage()
    {
    }

    public EnabledChannelsMessage(List<uint> channels, List<uint> disallowed)
    {
      this.channels = channels;
      this.disallowed = disallowed;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.channels.Count);
      for (int index = 0; index < this.channels.Count; ++index)
        writer.WriteByte((byte) this.channels[index]);
      writer.WriteShort((short) this.disallowed.Count);
      for (int index = 0; index < this.disallowed.Count; ++index)
        writer.WriteByte((byte) this.disallowed[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of channels.");
        this.channels.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of disallowed.");
        this.disallowed.Add(num2);
      }
    }
  }
}
