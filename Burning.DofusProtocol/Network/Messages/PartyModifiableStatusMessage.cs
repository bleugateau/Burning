using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyModifiableStatusMessage : AbstractPartyMessage
  {
    public new const uint Id = 6277;
    public bool enabled;

    public override uint MessageId
    {
      get
      {
        return 6277;
      }
    }

    public PartyModifiableStatusMessage()
    {
    }

    public PartyModifiableStatusMessage(uint partyId, bool enabled)
      : base(partyId)
    {
      this.enabled = enabled;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.enabled);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.enabled = reader.ReadBoolean();
    }
  }
}
