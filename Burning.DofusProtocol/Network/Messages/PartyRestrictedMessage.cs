using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyRestrictedMessage : AbstractPartyMessage
  {
    public new const uint Id = 6175;
    public bool restricted;

    public override uint MessageId
    {
      get
      {
        return 6175;
      }
    }

    public PartyRestrictedMessage()
    {
    }

    public PartyRestrictedMessage(uint partyId, bool restricted)
      : base(partyId)
    {
      this.restricted = restricted;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.restricted);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.restricted = reader.ReadBoolean();
    }
  }
}
