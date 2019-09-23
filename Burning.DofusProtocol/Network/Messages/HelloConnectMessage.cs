using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HelloConnectMessage : NetworkMessage
  {
    public List<int> key = new List<int>();
    public const uint Id = 3;
    public string salt;

    public override uint MessageId
    {
      get
      {
        return 3;
      }
    }

    public HelloConnectMessage()
    {
    }

    public HelloConnectMessage(string salt, List<int> key)
    {
      this.salt = salt;
      this.key = key;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.salt);
      writer.WriteVarInt(this.key.Count);
      for (int index = 0; index < this.key.Count; ++index)
        writer.WriteByte((byte) this.key[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.salt = reader.ReadUTF();
      uint num = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num; ++index)
        this.key.Add((int) reader.ReadByte());
    }
  }
}
