using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobAllowMultiCraftRequestMessage : NetworkMessage
  {
    public const uint Id = 5748;
    public bool enabled;

    public override uint MessageId
    {
      get
      {
        return 5748;
      }
    }

    public JobAllowMultiCraftRequestMessage()
    {
    }

    public JobAllowMultiCraftRequestMessage(bool enabled)
    {
      this.enabled = enabled;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.enabled);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.enabled = reader.ReadBoolean();
    }
  }
}
