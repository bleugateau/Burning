using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonKeyRingUpdateMessage : NetworkMessage
  {
    public const uint Id = 6296;
    public uint dungeonId;
    public bool available;

    public override uint MessageId
    {
      get
      {
        return 6296;
      }
    }

    public DungeonKeyRingUpdateMessage()
    {
    }

    public DungeonKeyRingUpdateMessage(uint dungeonId, bool available)
    {
      this.dungeonId = dungeonId;
      this.available = available;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      writer.WriteBoolean(this.available);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of DungeonKeyRingUpdateMessage.dungeonId.");
      this.available = reader.ReadBoolean();
    }
  }
}
