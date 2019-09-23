using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
  {
    public List<DungeonPartyFinderPlayer> addedPlayers = new List<DungeonPartyFinderPlayer>();
    public List<double> removedPlayersIds = new List<double>();
    public const uint Id = 6250;
    public uint dungeonId;

    public override uint MessageId
    {
      get
      {
        return 6250;
      }
    }

    public DungeonPartyFinderRoomContentUpdateMessage()
    {
    }

    public DungeonPartyFinderRoomContentUpdateMessage(
      uint dungeonId,
      List<DungeonPartyFinderPlayer> addedPlayers,
      List<double> removedPlayersIds)
    {
      this.dungeonId = dungeonId;
      this.addedPlayers = addedPlayers;
      this.removedPlayersIds = removedPlayersIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element dungeonId.");
      writer.WriteVarShort((short) this.dungeonId);
      writer.WriteShort((short) this.addedPlayers.Count);
      for (int index = 0; index < this.addedPlayers.Count; ++index)
        this.addedPlayers[index].Serialize(writer);
      writer.WriteShort((short) this.removedPlayersIds.Count);
      for (int index = 0; index < this.removedPlayersIds.Count; ++index)
      {
        if (this.removedPlayersIds[index] < 0.0 || this.removedPlayersIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.removedPlayersIds[index] + ") on element 3 (starting at 1) of removedPlayersIds.");
        writer.WriteVarLong((long) this.removedPlayersIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dungeonId = (uint) reader.ReadVarUhShort();
      if (this.dungeonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.dungeonId + ") on element of DungeonPartyFinderRoomContentUpdateMessage.dungeonId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        DungeonPartyFinderPlayer partyFinderPlayer = new DungeonPartyFinderPlayer();
        partyFinderPlayer.Deserialize(reader);
        this.addedPlayers.Add(partyFinderPlayer);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        double num3 = (double) reader.ReadVarUhLong();
        if (num3 < 0.0 || num3 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of removedPlayersIds.");
        this.removedPlayersIds.Add(num3);
      }
    }
  }
}
