using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NotificationListMessage : NetworkMessage
  {
    public List<int> flags = new List<int>();
    public const uint Id = 6087;

    public override uint MessageId
    {
      get
      {
        return 6087;
      }
    }

    public NotificationListMessage()
    {
    }

    public NotificationListMessage(List<int> flags)
    {
      this.flags = flags;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.flags.Count);
      for (int index = 0; index < this.flags.Count; ++index)
        writer.WriteVarInt(this.flags[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.flags.Add(reader.ReadVarInt());
    }
  }
}
