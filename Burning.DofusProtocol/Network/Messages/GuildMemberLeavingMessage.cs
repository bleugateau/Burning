using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMemberLeavingMessage : NetworkMessage
  {
    public const uint Id = 5923;
    public bool kicked;
    public double memberId;

    public override uint MessageId
    {
      get
      {
        return 5923;
      }
    }

    public GuildMemberLeavingMessage()
    {
    }

    public GuildMemberLeavingMessage(bool kicked, double memberId)
    {
      this.kicked = kicked;
      this.memberId = memberId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.kicked);
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.kicked = reader.ReadBoolean();
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of GuildMemberLeavingMessage.memberId.");
    }
  }
}
