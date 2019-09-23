using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyMemberArenaInformations : PartyMemberInformations
  {
    public new const uint Id = 391;
    public uint rank;

    public override uint TypeId
    {
      get
      {
        return 391;
      }
    }

    public PartyMemberArenaInformations()
    {
    }

    public PartyMemberArenaInformations(
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
      List<PartyEntityBaseInformation> entities,
      uint rank)
      : base(id, name, level, entityLook, breed, sex, lifePoints, maxLifePoints, prospecting, regenRate, initiative, alignmentSide, worldX, worldY, mapId, subAreaId, status, entities)
    {
      this.rank = rank;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarShort((short) this.rank);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.rank = (uint) reader.ReadVarUhShort();
      if (this.rank < 0U || this.rank > 20000U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of PartyMemberArenaInformations.rank.");
    }
  }
}
