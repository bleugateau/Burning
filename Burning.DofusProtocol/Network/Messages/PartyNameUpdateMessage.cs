using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyNameUpdateMessage : AbstractPartyMessage
  {
    public new const uint Id = 6502;
    public string partyName;

    public override uint MessageId
    {
      get
      {
        return 6502;
      }
    }

    public PartyNameUpdateMessage()
    {
    }

    public PartyNameUpdateMessage(uint partyId, string partyName)
      : base(partyId)
    {
      this.partyName = partyName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.partyName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.partyName = reader.ReadUTF();
    }
  }
}
