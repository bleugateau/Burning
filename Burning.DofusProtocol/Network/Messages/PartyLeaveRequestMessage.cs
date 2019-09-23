using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLeaveRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 5593;

    public override uint MessageId
    {
      get
      {
        return 5593;
      }
    }

    public PartyLeaveRequestMessage()
    {
    }

    public PartyLeaveRequestMessage(uint partyId)
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
