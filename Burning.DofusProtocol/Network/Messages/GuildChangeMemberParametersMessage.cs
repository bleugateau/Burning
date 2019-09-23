using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildChangeMemberParametersMessage : NetworkMessage
  {
    public const uint Id = 5549;
    public double memberId;
    public uint rank;
    public uint experienceGivenPercent;
    public uint rights;

    public override uint MessageId
    {
      get
      {
        return 5549;
      }
    }

    public GuildChangeMemberParametersMessage()
    {
    }

    public GuildChangeMemberParametersMessage(
      double memberId,
      uint rank,
      uint experienceGivenPercent,
      uint rights)
    {
      this.memberId = memberId;
      this.rank = rank;
      this.experienceGivenPercent = experienceGivenPercent;
      this.rights = rights;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarShort((short) this.rank);
      if (this.experienceGivenPercent < 0U || this.experienceGivenPercent > 100U)
        throw new Exception("Forbidden value (" + (object) this.experienceGivenPercent + ") on element experienceGivenPercent.");
      writer.WriteByte((byte) this.experienceGivenPercent);
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element rights.");
      writer.WriteVarInt((int) this.rights);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of GuildChangeMemberParametersMessage.memberId.");
      this.rank = (uint) reader.ReadVarUhShort();
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of GuildChangeMemberParametersMessage.rank.");
      this.experienceGivenPercent = (uint) reader.ReadByte();
      if (this.experienceGivenPercent < 0U || this.experienceGivenPercent > 100U)
        throw new Exception("Forbidden value (" + (object) this.experienceGivenPercent + ") on element of GuildChangeMemberParametersMessage.experienceGivenPercent.");
      this.rights = reader.ReadVarUhInt();
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element of GuildChangeMemberParametersMessage.rights.");
    }
  }
}
