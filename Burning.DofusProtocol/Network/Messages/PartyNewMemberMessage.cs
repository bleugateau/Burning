using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyNewMemberMessage : PartyUpdateMessage
  {
    public new const uint Id = 6306;

    public override uint MessageId
    {
      get
      {
        return 6306;
      }
    }

    public PartyNewMemberMessage()
    {
    }

    public PartyNewMemberMessage(uint partyId, PartyMemberInformations memberInformations)
      : base(partyId, memberInformations)
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
