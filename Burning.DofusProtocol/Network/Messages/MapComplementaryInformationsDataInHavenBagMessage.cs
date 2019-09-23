using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
  {
    public new const uint Id = 6622;
    public CharacterMinimalInformations ownerInformations;
    public int theme;
    public uint roomId;
    public uint maxRoomId;

    public override uint MessageId
    {
      get
      {
        return 6622;
      }
    }

    public MapComplementaryInformationsDataInHavenBagMessage()
    {
    }

    public MapComplementaryInformationsDataInHavenBagMessage(
      uint subAreaId,
      double mapId,
      List<HouseInformations> houses,
      List<GameRolePlayActorInformations> actors,
      List<InteractiveElement> interactiveElements,
      List<StatedElement> statedElements,
      List<MapObstacle> obstacles,
      List<FightCommonInformations> fights,
      bool hasAggressiveMonsters,
      FightStartingPositions fightStartPositions,
      CharacterMinimalInformations ownerInformations,
      int theme,
      uint roomId,
      uint maxRoomId)
      : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
    {
      this.ownerInformations = ownerInformations;
      this.theme = theme;
      this.roomId = roomId;
      this.maxRoomId = maxRoomId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.ownerInformations.Serialize(writer);
      writer.WriteByte((byte) this.theme);
      if (this.roomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.roomId + ") on element roomId.");
      writer.WriteByte((byte) this.roomId);
      if (this.maxRoomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxRoomId + ") on element maxRoomId.");
      writer.WriteByte((byte) this.maxRoomId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.ownerInformations = new CharacterMinimalInformations();
      this.ownerInformations.Deserialize(reader);
      this.theme = (int) reader.ReadByte();
      this.roomId = (uint) reader.ReadByte();
      if (this.roomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.roomId + ") on element of MapComplementaryInformationsDataInHavenBagMessage.roomId.");
      this.maxRoomId = (uint) reader.ReadByte();
      if (this.maxRoomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxRoomId + ") on element of MapComplementaryInformationsDataInHavenBagMessage.maxRoomId.");
    }
  }
}
