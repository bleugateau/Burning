using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HaapiSessionMessage : NetworkMessage
  {
    public const uint Id = 6769;
    public string key;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6769;
      }
    }

    public HaapiSessionMessage()
    {
    }

    public HaapiSessionMessage(string key, uint type)
    {
      this.key = key;
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.key);
      writer.WriteByte((byte) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.key = reader.ReadUTF();
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of HaapiSessionMessage.type.");
    }
  }
}
