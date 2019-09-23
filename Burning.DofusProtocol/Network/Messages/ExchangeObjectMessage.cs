using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectMessage : NetworkMessage
  {
    public const uint Id = 5515;
    public bool remote;

    public override uint MessageId
    {
      get
      {
        return 5515;
      }
    }

    public ExchangeObjectMessage()
    {
    }

    public ExchangeObjectMessage(bool remote)
    {
      this.remote = remote;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.remote);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.remote = reader.ReadBoolean();
    }
  }
}
