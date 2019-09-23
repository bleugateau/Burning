using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
  {
    public List<BreachBranch> branches = new List<BreachBranch>();
    public new const uint Id = 6791;
    public uint floor;
    public uint room;

    public override uint MessageId
    {
      get
      {
        return 6791;
      }
    }

    public MapComplementaryInformationsBreachMessage()
    {
    }

    public MapComplementaryInformationsBreachMessage(
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
      uint floor,
      uint room,
      List<BreachBranch> branches)
      : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, fightStartPositions)
    {
      this.floor = floor;
      this.room = room;
      this.branches = branches;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.floor < 0U)
        throw new Exception("Forbidden value (" + (object) this.floor + ") on element floor.");
      writer.WriteVarInt((int) this.floor);
      if (this.room < 0U)
        throw new Exception("Forbidden value (" + (object) this.room + ") on element room.");
      writer.WriteByte((byte) this.room);
      writer.WriteShort((short) this.branches.Count);
      for (int index = 0; index < this.branches.Count; ++index)
        this.branches[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.floor = reader.ReadVarUhInt();
      if (this.floor < 0U)
        throw new Exception("Forbidden value (" + (object) this.floor + ") on element of MapComplementaryInformationsBreachMessage.floor.");
      this.room = (uint) reader.ReadByte();
      if (this.room < 0U)
        throw new Exception("Forbidden value (" + (object) this.room + ") on element of MapComplementaryInformationsBreachMessage.room.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        BreachBranch breachBranch = new BreachBranch();
        breachBranch.Deserialize(reader);
        this.branches.Add(breachBranch);
      }
    }
  }
}
