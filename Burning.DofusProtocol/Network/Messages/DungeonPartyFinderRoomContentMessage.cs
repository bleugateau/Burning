using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonPartyFinderRoomContentMessage : NetworkMessage
  {
    public List<DungeonPartyFinderPlayer> players = new List<DungeonPartyFinderPlayer>();
    public const uint Id = 6247;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6247;
      }
    }

    public DungeonPartyFinderRoomContentMessage()
    {
    }

    public DungeonPartyFinderRoomContentMessage(
      uint dungeonId,
      List<DungeonPartyFinderPlayer> players)
    {
      this.dungeonId = dungeonId;
      this.players = players;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      writer.WriteShort((short) this.players.Count);
      for (int index = 0; index < this.players.Count; ++index)
        this.players[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of DungeonPartyFinderRoomContentMessage.dungeonId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        DungeonPartyFinderPlayer partyFinderPlayer = new DungeonPartyFinderPlayer();
        partyFinderPlayer.Deserialize(reader);
        this.players.Add(partyFinderPlayer);
      }
    }
  }
}
