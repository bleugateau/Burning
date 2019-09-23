using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CheckIntegrityMessage : NetworkMessage
  {
    public List<int> data = new List<int>();
    public const uint Id = 6372;

    public override uint MessageId
    {
      get
      {
        return 6372;
      }
    }

    public CheckIntegrityMessage()
    {
    }

    public CheckIntegrityMessage(List<int> data)
    {
      this.data = data;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.data.Count);
      for (int index = 0; index < this.data.Count; ++index)
        writer.WriteByte((byte) this.data[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num; ++index)
        this.data.Add((int) reader.ReadByte());
    }
  }
}
