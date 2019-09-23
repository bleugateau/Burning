using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyUpdateLightMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 6054;
    public double id;
    public uint lifePoints;
    public uint maxLifePoints;
    public uint prospecting;
    public uint regenRate;

    public override uint MessageId
    {
      get
      {
        return 6054;
      }
    }

    public PartyUpdateLightMessage()
    {
    }

    public PartyUpdateLightMessage(
      uint partyId,
      double id,
      uint lifePoints,
      uint maxLifePoints,
      uint prospecting,
      uint regenRate)
      : base(partyId)
    {
      this.id = id;
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
      this.prospecting = prospecting;
      this.regenRate = regenRate;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarLong((long) this.id);
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
      this.id = (double) reader.ReadVarUhLong();
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of PartyUpdateLightMessage.id.");
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of PartyUpdateLightMessage.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of PartyUpdateLightMessage.maxLifePoints.");
      this.prospecting = (uint) reader.ReadVarUhShort();
      if (this.prospecting < 0U)
        throw new Exception("Forbidden value (" + (object) this.prospecting + ") on element of PartyUpdateLightMessage.prospecting.");
      this.regenRate = (uint) reader.ReadByte();
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element of PartyUpdateLightMessage.regenRate.");
    }
  }
}
