using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyMemberInformations : CharacterBaseInformations
  {
    public List<PartyEntityBaseInformation> entities = new List<PartyEntityBaseInformation>();
    public new const uint Id = 90;
    public uint lifePoints;
    public uint maxLifePoints;
    public uint prospecting;
    public uint regenRate;
    public uint initiative;
    public int alignmentSide;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;
    public PlayerStatus status;

    public override uint TypeId
    {
      get
      {
        return 90;
      }
    }

    public PartyMemberInformations()
    {
    }

    public PartyMemberInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      bool sex,
      uint lifePoints,
      uint maxLifePoints,
      uint prospecting,
      uint regenRate,
      uint initiative,
      int alignmentSide,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      PlayerStatus status,
      List<PartyEntityBaseInformation> entities)
      : base(id, name, level, entityLook, breed, sex)
    {
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
      this.prospecting = prospecting;
      this.regenRate = regenRate;
      this.initiative = initiative;
      this.alignmentSide = alignmentSide;
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.status = status;
      this.entities = entities;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element lifePoints.");
      writer.WriteVarInt((int) this.lifePoints);
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element maxLifePoints.");
      writer.WriteVarInt((int) this.maxLifePoints);
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element prospecting.");
      writer.WriteVarShort((short) this.prospecting);
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element regenRate.");
      writer.WriteByte((byte) this.regenRate);
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element initiative.");
      writer.WriteVarShort((short) this.initiative);
      writer.WriteByte((byte) this.alignmentSide);
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element worldX.");
      writer.WriteShort((short) this.worldX);
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element worldY.");
      writer.WriteShort((short) this.worldY);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
      writer.WriteShort((short) this.entities.Count);
      for (int index = 0; index < this.entities.Count; ++index)
      {
        writer.WriteShort((short) this.entities[index].TypeId);
        this.entities[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of PartyMemberInformations.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of PartyMemberInformations.maxLifePoints.");
      this.prospecting = (uint) reader.ReadVarUhShort();
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element of PartyMemberInformations.prospecting.");
      this.regenRate = (uint) reader.ReadByte();
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element of PartyMemberInformations.regenRate.");
      this.initiative = (uint) reader.ReadVarUhShort();
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element of PartyMemberInformations.initiative.");
      this.alignmentSide = (int) reader.ReadByte();
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PartyMemberInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PartyMemberInformations.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of PartyMemberInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PartyMemberInformations.subAreaId.");
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PartyEntityBaseInformation instance = ProtocolTypeManager.GetInstance<PartyEntityBaseInformation>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.entities.Add(instance);
      }
    }
  }
}
