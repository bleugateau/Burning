using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyUpdateMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 5575;
    public PartyMemberInformations memberInformations;

    public override uint MessageId
    {
      get
      {
        return 5575;
      }
    }

    public PartyUpdateMessage()
    {
    }

    public PartyUpdateMessage(uint partyId, PartyMemberInformations memberInformations)
      : base(partyId)
    {
      this.memberInformations = memberInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.memberInformations.TypeId);
      this.memberInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.memberInformations = ProtocolTypeManager.GetInstance<PartyMemberInformations>((uint) reader.ReadUShort());
      this.memberInformations.Deserialize(reader);
    }
  }
}
