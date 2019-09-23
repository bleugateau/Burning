using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyNewGuestMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 6260;
    public PartyGuestInformations guest;

    public override uint MessageId
    {
      get
      {
        return 6260;
      }
    }

    public PartyNewGuestMessage()
    {
    }

    public PartyNewGuestMessage(uint partyId, PartyGuestInformations guest)
      : base(partyId)
    {
      this.guest = guest;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guest.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guest = new PartyGuestInformations();
      this.guest.Deserialize(reader);
    }
  }
}
