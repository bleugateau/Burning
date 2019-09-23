using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DebugInClientMessage : NetworkMessage
  {
    public const uint Id = 6028;
    public uint level;
    public string message;

    public override uint MessageId
    {
      get
      {
        return 6028;
      }
    }

    public DebugInClientMessage()
    {
    }

    public DebugInClientMessage(uint level, string message)
    {
      this.level = level;
      this.message = message;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.level);
      writer.WriteUTF(this.message);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of DebugInClientMessage.level.");
      this.message = reader.ReadUTF();
    }
  }
}
