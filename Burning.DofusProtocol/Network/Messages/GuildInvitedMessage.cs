using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInvitedMessage : NetworkMessage
  {
    public const uint Id = 5552;
    public double recruterId;
    public string recruterName;
    public BasicGuildInformations guildInfo;

    public override uint MessageId
    {
      get
      {
        return 5552;
      }
    }

    public GuildInvitedMessage()
    {
    }

    public GuildInvitedMessage(
      double recruterId,
      string recruterName,
      BasicGuildInformations guildInfo)
    {
      this.recruterId = recruterId;
      this.recruterName = recruterName;
      this.guildInfo = guildInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.recruterId < 0.0 || this.recruterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.recruterId + ") on element recruterId.");
      writer.WriteVarLong((long) this.recruterId);
      writer.WriteUTF(this.recruterName);
      this.guildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.recruterId = (double) reader.ReadVarUhLong();
      if (this.recruterId < 0.0 || this.recruterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.recruterId + ") on element of GuildInvitedMessage.recruterId.");
      this.recruterName = reader.ReadUTF();
      this.guildInfo = new BasicGuildInformations();
      this.guildInfo.Deserialize(reader);
    }
  }
}
