using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ContactLookRequestByNameMessage : ContactLookRequestMessage
  {
    public new const uint Id = 5933;
    public string playerName;

    public override uint MessageId
    {
      get
      {
        return 5933;
      }
    }

    public ContactLookRequestByNameMessage()
    {
    }

    public ContactLookRequestByNameMessage(uint requestId, uint contactType, string playerName)
      : base(requestId, contactType)
    {
      this.playerName = playerName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.playerName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerName = reader.ReadUTF();
    }
  }
}
