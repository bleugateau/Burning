using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceInvitationStateRecruterMessage : NetworkMessage
  {
    public const uint Id = 6396;
    public string recrutedName;
    public uint invitationState;

    public override uint MessageId
    {
      get
      {
        return 6396;
      }
    }

    public AllianceInvitationStateRecruterMessage()
    {
    }

    public AllianceInvitationStateRecruterMessage(string recrutedName, uint invitationState)
    {
      this.recrutedName = recrutedName;
      this.invitationState = invitationState;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.recrutedName);
      writer.WriteByte((byte) this.invitationState);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.recrutedName = reader.ReadUTF();
      this.invitationState = (uint) reader.ReadByte();
      if (this.invitationState < 0U)
        throw new Exception("Forbidden value (" + (object) this.invitationState + ") on element of AllianceInvitationStateRecruterMessage.invitationState.");
    }
  }
}
