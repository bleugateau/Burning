using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInvitationStateRecrutedMessage : NetworkMessage
  {
    public const uint Id = 5548;
    public uint invitationState;

    public override uint MessageId
    {
      get
      {
        return 5548;
      }
    }

    public GuildInvitationStateRecrutedMessage()
    {
    }

    public GuildInvitationStateRecrutedMessage(uint invitationState)
    {
      this.invitationState = invitationState;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.invitationState);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.invitationState = (uint) reader.ReadByte();
      if (this.invitationState < 0U)
        throw new Exception("Forbidden value (" + (object) this.invitationState + ") on element of GuildInvitationStateRecrutedMessage.invitationState.");
    }
  }
}
