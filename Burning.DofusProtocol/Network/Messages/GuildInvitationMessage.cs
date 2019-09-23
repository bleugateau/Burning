using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInvitationMessage : NetworkMessage
  {
    public const uint Id = 5551;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 5551;
      }
    }

    public GuildInvitationMessage()
    {
    }

    public GuildInvitationMessage(double targetId)
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
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GuildInvitationMessage.targetId.");
    }
  }
}
