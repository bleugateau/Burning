using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredAddRequestMessage : NetworkMessage
  {
    public const uint Id = 5673;
    public string name;
    public bool session;

    public override uint MessageId
    {
      get
      {
        return 5673;
      }
    }

    public IgnoredAddRequestMessage()
    {
    }

    public IgnoredAddRequestMessage(string name, bool session)
    {
      this.name = name;
      this.session = session;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
      writer.WriteBoolean(this.session);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
      this.session = reader.ReadBoolean();
    }
  }
}
