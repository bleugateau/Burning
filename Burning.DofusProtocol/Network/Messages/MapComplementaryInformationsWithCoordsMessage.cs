using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
  {
    public new const uint Id = 6268;
    public int worldX;
    public int worldY;

    public override uint MessageId
    {
      get
      {
        return 6268;
      }
    }

    public MapComplementaryInformationsWithCoordsMessage()
    {
    }

    public MapComplementaryInformationsWithCoordsMessage(
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
      int worldX,
      int worldY)
      : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
    {
      this.worldX = worldX;
      this.worldY = worldY;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of MapComplementaryInformationsWithCoordsMessage.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of MapComplementaryInformationsWithCoordsMessage.worldY.");
    }
  }
}
