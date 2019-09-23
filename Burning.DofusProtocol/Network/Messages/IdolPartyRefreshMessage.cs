using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolPartyRefreshMessage : NetworkMessage
  {
    public const uint Id = 6583;
    public PartyIdol partyIdol;

    public override uint MessageId
    {
      get
      {
        return 6583;
      }
    }

    public IdolPartyRefreshMessage()
    {
    }

    public IdolPartyRefreshMessage(PartyIdol partyIdol)
    {
      this.partyIdol = partyIdol;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.partyIdol.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.partyIdol = new PartyIdol();
      this.partyIdol.Deserialize(reader);
    }
  }
}
