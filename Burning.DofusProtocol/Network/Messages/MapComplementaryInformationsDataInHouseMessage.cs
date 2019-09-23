using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
  {
    public new const uint Id = 6130;
    public HouseInformationsInside currentHouse;

    public override uint MessageId
    {
      get
      {
        return 6130;
      }
    }

    public MapComplementaryInformationsDataInHouseMessage()
    {
    }

    public MapComplementaryInformationsDataInHouseMessage(
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
      HouseInformationsInside currentHouse)
      : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
    {
      this.currentHouse = currentHouse;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.currentHouse.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.currentHouse = new HouseInformationsInside();
      this.currentHouse.Deserialize(reader);
    }
  }
}
