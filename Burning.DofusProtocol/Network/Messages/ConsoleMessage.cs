using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ConsoleMessage : NetworkMessage
  {
    public const uint Id = 75;
    public uint type;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 75;
      }
    }

    public ConsoleMessage()
    {
    }

    public ConsoleMessage(uint type, string content)
    {
      this.type = type;
      this.content = content;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
      writer.WriteUTF(this.content);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of ConsoleMessage.type.");
      this.content = reader.ReadUTF();
    }
  }
}
