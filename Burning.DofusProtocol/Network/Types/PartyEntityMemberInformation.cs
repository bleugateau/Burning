using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyEntityMemberInformation : PartyEntityBaseInformation
  {
    public new const uint Id = 550;
    public uint initiative;
    public uint lifePoints;
    public uint maxLifePoints;
    public uint prospecting;
    public uint regenRate;

    public override uint TypeId
    {
      get
      {
        return 550;
      }
    }

    public PartyEntityMemberInformation()
    {
    }

    public PartyEntityMemberInformation(
      uint indexId,
      uint entityModelId,
      EntityLook entityLook,
      uint initiative,
      uint lifePoints,
      uint maxLifePoints,
      uint prospecting,
      uint regenRate)
      : base(indexId, entityModelId, entityLook)
    {
      this.initiative = initiative;
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
      this.prospecting = prospecting;
      this.regenRate = regenRate;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element initiative.");
      writer.WriteVarShort((short) this.initiative);
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
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.initiative = (uint) reader.ReadVarUhShort();
      if (this.initiative < 0U)
        throw new Exception("Forbidden value (" + (object) this.initiative + ") on element of PartyEntityMemberInformation.initiative.");
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of PartyEntityMemberInformation.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of PartyEntityMemberInformation.maxLifePoints.");
      this.prospecting = (uint) reader.ReadVarUhShort();
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element of PartyEntityMemberInformation.prospecting.");
      this.regenRate = (uint) reader.ReadByte();
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element of PartyEntityMemberInformation.regenRate.");
    }
  }
}
