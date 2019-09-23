using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class ConnectionPasswordMessage : NetworkMessage
  {
    public const uint Id = 7987;

    public override uint MessageId
    {
      get
      {
        return 7987;
      }
    }

    public string Password { get; set; }

    public ConnectionPasswordMessage()
    {
    }

    public ConnectionPasswordMessage(string password)
    {
      this.Password = password;
    }

    public override void Deserialize(IDataReader reader)
    {
      this.Password = reader.ReadUTF();
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.Password);
    }
  }
}
