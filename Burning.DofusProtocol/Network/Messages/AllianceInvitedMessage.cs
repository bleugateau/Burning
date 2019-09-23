using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceInvitedMessage : NetworkMessage
  {
    public const uint Id = 6397;
    public double recruterId;
    public string recruterName;
    public BasicNamedAllianceInformations allianceInfo;

    public override uint MessageId
    {
      get
      {
        return 6397;
      }
    }

    public AllianceInvitedMessage()
    {
    }

    public AllianceInvitedMessage(
      double recruterId,
      string recruterName,
      BasicNamedAllianceInformations allianceInfo)
    {
      this.recruterId = recruterId;
      this.recruterName = recruterName;
      this.allianceInfo = allianceInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.recruterId < 0.0 || this.recruterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.recruterId + ") on element recruterId.");
      writer.WriteVarLong((long) this.recruterId);
      writer.WriteUTF(this.recruterName);
      this.allianceInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.recruterId = (double) reader.ReadVarUhLong();
      if (this.recruterId < 0.0 || this.recruterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.recruterId + ") on element of AllianceInvitedMessage.recruterId.");
      this.recruterName = reader.ReadUTF();
      this.allianceInfo = new BasicNamedAllianceInformations();
      this.allianceInfo.Deserialize(reader);
    }
  }
}
