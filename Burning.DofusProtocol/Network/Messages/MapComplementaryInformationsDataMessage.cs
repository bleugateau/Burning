using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsDataMessage : NetworkMessage
  {
    public List<HouseInformations> houses = new List<HouseInformations>();
    public List<GameRolePlayActorInformations> actors = new List<GameRolePlayActorInformations>();
    public List<InteractiveElement> interactiveElements = new List<InteractiveElement>();
    public List<StatedElement> statedElements = new List<StatedElement>();
    public List<MapObstacle> obstacles = new List<MapObstacle>();
    public List<FightCommonInformations> fights = new List<FightCommonInformations>();
    public const uint Id = 226;
    public uint subAreaId;
    public double mapId;
    public bool hasAggressiveMonsters;
    public FightStartingPositions fightStartPositions;

    public override uint MessageId
    {
      get
      {
        return 226;
      }
    }

    public MapComplementaryInformationsDataMessage()
    {
    }

    public MapComplementaryInformationsDataMessage(
      uint subAreaId,
      double mapId,
      List<HouseInformations> houses,
      List<GameRolePlayActorInformations> actors,
      List<InteractiveElement> interactiveElements,
      List<StatedElement> statedElements,
      List<MapObstacle> obstacles,
      List<FightCommonInformations> fights,
      bool hasAggressiveMonsters,
      FightStartingPositions fightStartPositions)
    {
      this.subAreaId = subAreaId;
      this.mapId = mapId;
      this.houses = houses;
      this.actors = actors;
      this.interactiveElements = interactiveElements;
      this.statedElements = statedElements;
      this.obstacles = obstacles;
      this.fights = fights;
      this.hasAggressiveMonsters = hasAggressiveMonsters;
      this.fightStartPositions = fightStartPositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteShort((short) this.houses.Count);
      for (int index = 0; index < this.houses.Count; ++index)
      {
        writer.WriteShort((short) this.houses[index].TypeId);
        this.houses[index].Serialize(writer);
      }
      writer.WriteShort((short) this.actors.Count);
      for (int index = 0; index < this.actors.Count; ++index)
      {
        writer.WriteShort((short) this.actors[index].TypeId);
        this.actors[index].Serialize(writer);
      }
      writer.WriteShort((short) this.interactiveElements.Count);
      for (int index = 0; index < this.interactiveElements.Count; ++index)
      {
        writer.WriteShort((short) this.interactiveElements[index].TypeId);
        this.interactiveElements[index].Serialize(writer);
      }
      writer.WriteShort((short) this.statedElements.Count);
      for (int index = 0; index < this.statedElements.Count; ++index)
        this.statedElements[index].Serialize(writer);
      writer.WriteShort((short) this.obstacles.Count);
      for (int index = 0; index < this.obstacles.Count; ++index)
        this.obstacles[index].Serialize(writer);
      writer.WriteShort((short) this.fights.Count);
      for (int index = 0; index < this.fights.Count; ++index)
        this.fights[index].Serialize(writer);
      writer.WriteBoolean(this.hasAggressiveMonsters);
      this.fightStartPositions.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of MapComplementaryInformationsDataMessage.subAreaId.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of MapComplementaryInformationsDataMessage.mapId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        HouseInformations instance = ProtocolTypeManager.GetInstance<HouseInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.houses.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        GameRolePlayActorInformations instance = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.actors.Add(instance);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        InteractiveElement instance = ProtocolTypeManager.GetInstance<InteractiveElement>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.interactiveElements.Add(instance);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        StatedElement statedElement = new StatedElement();
        statedElement.Deserialize(reader);
        this.statedElements.Add(statedElement);
      }
      uint num5 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num5; ++index)
      {
        MapObstacle mapObstacle = new MapObstacle();
        mapObstacle.Deserialize(reader);
        this.obstacles.Add(mapObstacle);
      }
      uint num6 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num6; ++index)
      {
        FightCommonInformations commonInformations = new FightCommonInformations();
        commonInformations.Deserialize(reader);
        this.fights.Add(commonInformations);
      }
      this.hasAggressiveMonsters = reader.ReadBoolean();
      this.fightStartPositions = new FightStartingPositions();
      this.fightStartPositions.Deserialize(reader);
    }
  }
}
