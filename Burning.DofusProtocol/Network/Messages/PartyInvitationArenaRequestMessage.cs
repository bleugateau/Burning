using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
  {
    public new const uint Id = 6283;

    public override uint MessageId
    {
      get
      {
        return 6283;
      }
    }

    public PartyInvitationArenaRequestMessage()
    {
    }

    public PartyInvitationArenaRequestMessage(string name)
      : base(name)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
