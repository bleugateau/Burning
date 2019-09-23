using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HavenBagPackListMessage : NetworkMessage
  {
    public List<int> packIds = new List<int>();
    public const uint Id = 6620;

    public override uint MessageId
    {
      get
      {
        return 6620;
      }
    }

    public HavenBagPackListMessage()
    {
    }

    public HavenBagPackListMessage(List<int> packIds)
    {
      this.packIds = packIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.packIds.Count);
      for (int index = 0; index < this.packIds.Count; ++index)
        writer.WriteByte((byte) this.packIds[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.packIds.Add((int) reader.ReadByte());
    }
  }
}
