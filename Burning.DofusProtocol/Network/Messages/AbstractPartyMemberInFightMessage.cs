using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractPartyMemberInFightMessage : AbstractPartyMessage
  {
    public new const uint Id = 6825;
    public uint reason;
    public double memberId;
    public uint memberAccountId;
    public string memberName;
    public uint fightId;
    public int timeBeforeFightStart;

    public override uint MessageId
    {
      get
      {
        return 6825;
      }
    }

    public AbstractPartyMemberInFightMessage()
    {
    }

    public AbstractPartyMemberInFightMessage(
      uint partyId,
      uint reason,
      double memberId,
      uint memberAccountId,
      string memberName,
      uint fightId,
      int timeBeforeFightStart)
      : base(partyId)
    {
      this.reason = reason;
      this.memberId = memberId;
      this.memberAccountId = memberAccountId;
      this.memberName = memberName;
      this.fightId = fightId;
      this.timeBeforeFightStart = timeBeforeFightStart;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.reason);
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      if (this.memberAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberAccountId + ") on element memberAccountId.");
      writer.WriteInt((int) this.memberAccountId);
      writer.WriteUTF(this.memberName);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteVarShort((short) this.timeBeforeFightStart);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.reason = (uint) reader.ReadByte();
      if (this.reason < 0U)
        throw new Exception("Forbidden value (" + (object) this.reason + ") on element of AbstractPartyMemberInFightMessage.reason.");
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of AbstractPartyMemberInFightMessage.memberId.");
      this.memberAccountId = (uint) reader.ReadInt();
      if (this.memberAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberAccountId + ") on element of AbstractPartyMemberInFightMessage.memberAccountId.");
      this.memberName = reader.ReadUTF();
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of AbstractPartyMemberInFightMessage.fightId.");
      this.timeBeforeFightStart = (int) reader.ReadVarShort();
    }
  }
}
