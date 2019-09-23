using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SetEnableAVARequestMessage : NetworkMessage
  {
    public const uint Id = 6443;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6443;
      }
    }

    public SetEnableAVARequestMessage()
    {
    }

    public SetEnableAVARequestMessage(bool enable)
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
