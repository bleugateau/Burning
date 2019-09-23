using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicPingMessage : NetworkMessage
  {
    public const uint Id = 182;
    public bool quiet;

    public override uint MessageId
    {
      get
      {
        return 182;
      }
    }

    public BasicPingMessage()
    {
    }

    public BasicPingMessage(bool quiet)
    {
      this.quiet = quiet;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.quiet);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.quiet = reader.ReadBoolean();
    }
  }
}
