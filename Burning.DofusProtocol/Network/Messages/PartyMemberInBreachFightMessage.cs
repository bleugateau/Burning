using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
  {
    public new const uint Id = 6824;
    public uint floor;
    public uint room;

    public override uint MessageId
    {
      get
      {
        return 6824;
      }
    }

    public PartyMemberInBreachFightMessage()
    {
    }

    public PartyMemberInBreachFightMessage(
      uint partyId,
      uint reason,
      double memberId,
      uint memberAccountId,
      string memberName,
      uint fightId,
      int timeBeforeFightStart,
      uint floor,
      uint room)
      : base(partyId, reason, memberId, memberAccountId, memberName, fightId, timeBeforeFightStart)
    {
      this.floor = floor;
      this.room = room;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.floor = reader.ReadVarUhInt();
      if (this.floor < 0U)
        throw new Exception("Forbidden value (" + (object) this.floor + ") on element of PartyMemberInBreachFightMessage.floor.");
      this.room = (uint) reader.ReadByte();
      if (this.room < 0U)
        throw new Exception("Forbidden value (" + (object) this.room + ") on element of PartyMemberInBreachFightMessage.room.");
    }
  }
}
