using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationDetailsMessage : AbstractPartyMessage
  {
    public List<PartyInvitationMemberInformations> members = new List<PartyInvitationMemberInformations>();
    public List<PartyGuestInformations> guests = new List<PartyGuestInformations>();
    public new const uint Id = 6263;
    public uint partyType;
    public string partyName;
    public double fromId;
    public string fromName;
    public double leaderId;

    public override uint MessageId
    {
      get
      {
        return 6263;
      }
    }

    public PartyInvitationDetailsMessage()
    {
    }

    public PartyInvitationDetailsMessage(
      uint partyId,
      uint partyType,
      string partyName,
      double fromId,
      string fromName,
      double leaderId,
      List<PartyInvitationMemberInformations> members,
      List<PartyGuestInformations> guests)
      : base(partyId)
    {
      this.partyType = partyType;
      this.partyName = partyName;
      this.fromId = fromId;
      this.fromName = fromName;
      this.leaderId = leaderId;
      this.members = members;
      this.guests = guests;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.partyType);
      writer.WriteUTF(this.partyName);
      if (this.fromId < 0.0 || this.fromId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fromId + ") on element fromId.");
      writer.WriteVarLong((long) this.fromId);
      writer.WriteUTF(this.fromName);
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element leaderId.");
      writer.WriteVarLong((long) this.leaderId);
      writer.WriteShort((short) this.members.Count);
      for (int index = 0; index < this.members.Count; ++index)
      {
        writer.WriteShort((short) this.members[index].TypeId);
        this.members[index].Serialize(writer);
      }
      writer.WriteShort((short) this.guests.Count);
      for (int index = 0; index < this.guests.Count; ++index)
        this.guests[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.partyType = (uint) reader.ReadByte();
      if (this.partyType < 0U)
        throw new Exception("Forbidden value (" + (object) this.partyType + ") on element of PartyInvitationDetailsMessage.partyType.");
      this.partyName = reader.ReadUTF();
      this.fromId = (double) reader.ReadVarUhLong();
      if (this.fromId < 0.0 || this.fromId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fromId + ") on element of PartyInvitationDetailsMessage.fromId.");
      this.fromName = reader.ReadUTF();
      this.leaderId = (double) reader.ReadVarUhLong();
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element of PartyInvitationDetailsMessage.leaderId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        PartyInvitationMemberInformations instance = ProtocolTypeManager.GetInstance<PartyInvitationMemberInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.members.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        PartyGuestInformations guestInformations = new PartyGuestInformations();
        guestInformations.Deserialize(reader);
        this.guests.Add(guestInformations);
      }
    }
  }
}
