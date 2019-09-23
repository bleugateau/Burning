using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMemberOnlineStatusMessage : NetworkMessage
  {
    public const uint Id = 6061;
    public double memberId;
    public bool online;

    public override uint MessageId
    {
      get
      {
        return 6061;
      }
    }

    public GuildMemberOnlineStatusMessage()
    {
    }

    public GuildMemberOnlineStatusMessage(double memberId, bool online)
    {
      this.memberId = memberId;
      this.online = online;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      writer.WriteBoolean(this.online);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of GuildMemberOnlineStatusMessage.memberId.");
      this.online = reader.ReadBoolean();
    }
  }
}
