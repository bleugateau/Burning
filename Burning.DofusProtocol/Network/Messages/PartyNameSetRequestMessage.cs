using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyNameSetRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 6503;
    public string partyName;

    public override uint MessageId
    {
      get
      {
        return 6503;
      }
    }

    public PartyNameSetRequestMessage()
    {
    }

    public PartyNameSetRequestMessage(uint partyId, string partyName)
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
