using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyJoinMessage : AbstractPartyMessage
  {
    public List<PartyMemberInformations> members = new List<PartyMemberInformations>();
    public List<PartyGuestInformations> guests = new List<PartyGuestInformations>();
    public new const uint Id = 5576;
    public uint partyType;
    public double partyLeaderId;
    public uint maxParticipants;
    public bool restricted;
    public string partyName;

    public override uint MessageId
    {
      get
      {
        return 5576;
      }
    }

    public PartyJoinMessage()
    {
    }

    public PartyJoinMessage(
      uint partyId,
      uint partyType,
      double partyLeaderId,
      uint maxParticipants,
      List<PartyMemberInformations> members,
      List<PartyGuestInformations> guests,
      bool restricted,
      string partyName)
      : base(partyId)
    {
      this.partyType = partyType;
      this.partyLeaderId = partyLeaderId;
      this.maxParticipants = maxParticipants;
      this.members = members;
      this.guests = guests;
      this.restricted = restricted;
      this.partyName = partyName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.partyType);
      if (this.partyLeaderId < 0.0 || this.partyLeaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.partyLeaderId + ") on element partyLeaderId.");
      writer.WriteVarLong((long) this.partyLeaderId);
      if (this.maxParticipants < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxParticipants + ") on element maxParticipants.");
      writer.WriteByte((byte) this.maxParticipants);
      writer.WriteShort((short) this.members.Count);
      for (int index = 0; index < this.members.Count; ++index)
      {
        writer.WriteShort((short) this.members[index].TypeId);
        this.members[index].Serialize(writer);
      }
      writer.WriteShort((short) this.guests.Count);
      for (int index = 0; index < this.guests.Count; ++index)
        this.guests[index].Serialize(writer);
      writer.WriteBoolean(this.restricted);
      writer.WriteUTF(this.partyName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.partyType = (uint) reader.ReadByte();
      if (this.partyType < 0U)
        throw new Exception("Forbidden value (" + (object) this.partyType + ") on element of PartyJoinMessage.partyType.");
      this.partyLeaderId = (double) reader.ReadVarUhLong();
      if (this.partyLeaderId < 0.0 || this.partyLeaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.partyLeaderId + ") on element of PartyJoinMessage.partyLeaderId.");
      this.maxParticipants = (uint) reader.ReadByte();
      if (this.maxParticipants < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxParticipants + ") on element of PartyJoinMessage.maxParticipants.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        PartyMemberInformations instance = ProtocolTypeManager.GetInstance<PartyMemberInformations>((uint) reader.ReadUShort());
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
      this.restricted = reader.ReadBoolean();
      this.partyName = reader.ReadUTF();
    }
  }
}
