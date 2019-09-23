using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicWhoIsNoMatchMessage : NetworkMessage
  {
    public const uint Id = 179;
    public string search;

    public override uint MessageId
    {
      get
      {
        return 179;
      }
    }

    public BasicWhoIsNoMatchMessage()
    {
    }

    public BasicWhoIsNoMatchMessage(string search)
    {
      this.search = search;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.search);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.search = reader.ReadUTF();
    }
  }
}
