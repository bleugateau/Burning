using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
  {
    public new const uint Id = 5588;
    public bool enabled;

    public override uint MessageId
    {
      get
      {
        return 5588;
      }
    }

    public PartyFollowThisMemberRequestMessage()
    {
    }

    public PartyFollowThisMemberRequestMessage(uint partyId, double playerId, bool enabled)
      : base(partyId, playerId)
    {
      this.enabled = enabled;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.enabled);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.enabled = reader.ReadBoolean();
    }
  }
}
