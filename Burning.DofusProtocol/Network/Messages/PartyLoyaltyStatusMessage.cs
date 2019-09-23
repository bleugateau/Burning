using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLoyaltyStatusMessage : AbstractPartyMessage
  {
    public new const uint Id = 6270;
    public bool loyal;

    public override uint MessageId
    {
      get
      {
        return 6270;
      }
    }

    public PartyLoyaltyStatusMessage()
    {
    }

    public PartyLoyaltyStatusMessage(uint partyId, bool loyal)
      : base(partyId)
    {
      this.loyal = loyal;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.loyal);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.loyal = reader.ReadBoolean();
    }
  }
}
