using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SetEnablePVPRequestMessage : NetworkMessage
  {
    public const uint Id = 1810;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 1810;
      }
    }

    public SetEnablePVPRequestMessage()
    {
    }

    public SetEnablePVPRequestMessage(bool enable)
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
