using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AuthenticationTicketMessage : NetworkMessage
  {
    public const uint Id = 110;
    public string lang;
    public string ticket;

    public override uint MessageId
    {
      get
      {
        return 110;
      }
    }

    public AuthenticationTicketMessage()
    {
    }

    public AuthenticationTicketMessage(string lang, string ticket)
    {
      this.lang = lang;
      this.ticket = ticket;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.lang);
      writer.WriteUTF(this.ticket);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.lang = reader.ReadUTF();
      this.ticket = reader.ReadUTF();
    }
  }
}
