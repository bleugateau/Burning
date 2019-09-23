using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceInvitationMessage : NetworkMessage
  {
    public const uint Id = 6395;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 6395;
      }
    }

    public AllianceInvitationMessage()
    {
    }

    public AllianceInvitationMessage(double targetId)
    {
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteVarLong((long) this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.targetId = (double) reader.ReadVarUhLong();
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of AllianceInvitationMessage.targetId.");
    }
  }
}
