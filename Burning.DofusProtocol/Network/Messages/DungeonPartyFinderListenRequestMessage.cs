using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonPartyFinderListenRequestMessage : NetworkMessage
  {
    public const uint Id = 6246;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6246;
      }
    }

    public DungeonPartyFinderListenRequestMessage()
    {
    }

    public DungeonPartyFinderListenRequestMessage(uint dungeonId)
    {
      this.dungeonId = dungeonId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of DungeonPartyFinderListenRequestMessage.dungeonId.");
    }
  }
}
