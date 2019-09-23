using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLeaveMessage : AbstractPartyMessage
  {
    public new const uint Id = 5594;

    public override uint MessageId
    {
      get
      {
        return 5594;
      }
    }

    public PartyLeaveMessage()
    {
    }

    public PartyLeaveMessage(uint partyId)
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
