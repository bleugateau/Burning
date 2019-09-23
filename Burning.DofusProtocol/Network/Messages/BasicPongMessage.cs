using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicPongMessage : NetworkMessage
  {
    public const uint Id = 183;
    public bool quiet;

    public override uint MessageId
    {
      get
      {
        return 183;
      }
    }

    public BasicPongMessage()
    {
    }

    public BasicPongMessage(bool quiet)
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
