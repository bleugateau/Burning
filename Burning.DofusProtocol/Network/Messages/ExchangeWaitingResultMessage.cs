using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeWaitingResultMessage : NetworkMessage
  {
    public const uint Id = 5786;
    public bool bwait;

    public override uint MessageId
    {
      get
      {
        return 5786;
      }
    }

    public ExchangeWaitingResultMessage()
    {
    }

    public ExchangeWaitingResultMessage(bool bwait)
    {
      this.bwait = bwait;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.bwait);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.bwait = reader.ReadBoolean();
    }
  }
}
