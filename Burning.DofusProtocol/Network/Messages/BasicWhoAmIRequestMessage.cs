using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicWhoAmIRequestMessage : NetworkMessage
  {
    public const uint Id = 5664;
    public bool verbose;

    public override uint MessageId
    {
      get
      {
        return 5664;
      }
    }

    public BasicWhoAmIRequestMessage()
    {
    }

    public BasicWhoAmIRequestMessage(bool verbose)
    {
      this.verbose = verbose;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.verbose);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.verbose = reader.ReadBoolean();
    }
  }
}
