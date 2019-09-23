using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CheckFileRequestMessage : NetworkMessage
  {
    public const uint Id = 6154;
    public string filename;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6154;
      }
    }

    public CheckFileRequestMessage()
    {
    }

    public CheckFileRequestMessage(string filename, uint type)
    {
      this.filename = filename;
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.filename);
      writer.WriteByte((byte) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.filename = reader.ReadUTF();
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of CheckFileRequestMessage.type.");
    }
  }
}
