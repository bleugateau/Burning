using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationMessage : AbstractPartyMessage
  {
    public new const uint Id = 5586;
    public uint partyType;
    public string partyName;
    public uint maxParticipants;
    public double fromId;
    public string fromName;
    public double toId;

    public override uint MessageId
    {
      get
      {
        return 5586;
      }
    }

    public PartyInvitationMessage()
    {
    }

    public PartyInvitationMessage(
      uint partyId,
      uint partyType,
      string partyName,
      uint maxParticipants,
      double fromId,
      string fromName,
      double toId)
      : base(partyId)
    {
      this.partyType = partyType;
      this.partyName = partyName;
      this.maxParticipants = maxParticipants;
      this.fromId = fromId;
      this.fromName = fromName;
      this.toId = toId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.partyType);
      writer.WriteUTF(this.partyName);
      if (this.maxParticipants < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxParticipants + ") on element maxParticipants.");
      writer.WriteByte((byte) this.maxParticipants);
      if (this.fromId < 0.0 || this.fromId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fromId + ") on element fromId.");
      writer.WriteVarLong((long) this.fromId);
      writer.WriteUTF(this.fromName);
      if (this.toId < 0.0 || this.toId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.toId + ") on element toId.");
      writer.WriteVarLong((long) this.toId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.partyType = (uint) reader.ReadByte();
      if (this.partyType < 0U)
        throw new Exception("Forbidden value (" + (object) this.partyType + ") on element of PartyInvitationMessage.partyType.");
      this.partyName = reader.ReadUTF();
      this.maxParticipants = (uint) reader.ReadByte();
      if (this.maxParticipants < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxParticipants + ") on element of PartyInvitationMessage.maxParticipants.");
      this.fromId = (double) reader.ReadVarUhLong();
      if (this.fromId < 0.0 || this.fromId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fromId + ") on element of PartyInvitationMessage.fromId.");
      this.fromName = reader.ReadUTF();
      this.toId = (double) reader.ReadVarUhLong();
      if (this.toId < 0.0 || this.toId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.toId + ") on element of PartyInvitationMessage.toId.");
    }
  }
}
