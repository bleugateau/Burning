using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLocateMembersRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 5587;

    public override uint MessageId
    {
      get
      {
        return 5587;
      }
    }

    public PartyLocateMembersRequestMessage()
    {
    }

    public PartyLocateMembersRequestMessage(uint partyId)
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
