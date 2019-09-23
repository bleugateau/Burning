using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CheckFileMessage : NetworkMessage
  {
    public const uint Id = 6156;
    public string filenameHash;
    public uint type;
    public string value;

    public override uint MessageId
    {
      get
      {
        return 6156;
      }
    }

    public CheckFileMessage()
    {
    }

    public CheckFileMessage(string filenameHash, uint type, string value)
    {
      this.filenameHash = filenameHash;
      this.type = type;
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.filenameHash);
      writer.WriteByte((byte) this.type);
      writer.WriteUTF(this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.filenameHash = reader.ReadUTF();
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of CheckFileMessage.type.");
      this.value = reader.ReadUTF();
    }
  }
}
