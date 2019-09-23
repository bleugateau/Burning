using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsAnomalyMessage : MapComplementaryInformationsDataMessage
  {
    public new const uint Id = 6828;
    public uint level;
    public double closingTime;

    public override uint MessageId
    {
      get
      {
        return 6828;
      }
    }

    public MapComplementaryInformationsAnomalyMessage()
    {
    }

    public MapComplementaryInformationsAnomalyMessage(
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
      uint level,
      double closingTime)
      : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
    {
      this.level = level;
      this.closingTime = closingTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      if (this.closingTime < 0.0 || this.closingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.closingTime + ") on element closingTime.");
      writer.WriteVarLong((long) this.closingTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of MapComplementaryInformationsAnomalyMessage.level.");
      this.closingTime = (double) reader.ReadVarUhLong();
      if (this.closingTime < 0.0 || this.closingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.closingTime + ") on element of MapComplementaryInformationsAnomalyMessage.closingTime.");
    }
  }
}
