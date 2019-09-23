using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyDeletedMessage : AbstractPartyMessage
  {
    public new const uint Id = 6261;

    public override uint MessageId
    {
      get
      {
        return 6261;
      }
    }

    public PartyDeletedMessage()
    {
    }

    public PartyDeletedMessage(uint partyId)
      : base(partyId)
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
