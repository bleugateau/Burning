using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class WarnOnPermaDeathMessage : NetworkMessage
  {
    public const uint Id = 6512;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6512;
      }
    }

    public WarnOnPermaDeathMessage()
    {
    }

    public WarnOnPermaDeathMessage(bool enable)
    {
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.enable);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.enable = reader.ReadBoolean();
    }
  }
}
