using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyInvitationMemberInformations : CharacterBaseInformations
  {
    public List<PartyEntityBaseInformation> entities = new List<PartyEntityBaseInformation>();
    public new const uint Id = 376;
    public int worldX;
    public int worldY;
    public double mapId;
    public uint subAreaId;

    public override uint TypeId
    {
      get
      {
        return 376;
      }
    }

    public PartyInvitationMemberInformations()
    {
    }

    public PartyInvitationMemberInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      bool sex,
      int worldX,
      int worldY,
      double mapId,
      uint subAreaId,
      List<PartyEntityBaseInformation> entities)
      : base(id, name, level, entityLook, breed, sex)
    {
      this.worldX = worldX;
      this.worldY = worldY;
      this.mapId = mapId;
      this.subAreaId = subAreaId;
      this.entities = entities;
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
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteShort((short) this.entities.Count);
      for (int index = 0; index < this.entities.Count; ++index)
        this.entities[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.worldX = (int) reader.ReadShort();
      if (this.worldX < -255 || this.worldX > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldX + ") on element of PartyInvitationMemberInformations.worldX.");
      this.worldY = (int) reader.ReadShort();
      if (this.worldY < -255 || this.worldY > (int) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.worldY + ") on element of PartyInvitationMemberInformations.worldY.");
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of PartyInvitationMemberInformations.mapId.");
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PartyInvitationMemberInformations.subAreaId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PartyEntityBaseInformation entityBaseInformation = new PartyEntityBaseInformation();
        entityBaseInformation.Deserialize(reader);
        this.entities.Add(entityBaseInformation);
      }
    }
  }
}
