using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 6269;
    public bool loyal;

    public override uint MessageId
    {
      get
      {
        return 6269;
      }
    }

    public PartyPledgeLoyaltyRequestMessage()
    {
    }

    public PartyPledgeLoyaltyRequestMessage(uint partyId, bool loyal)
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
