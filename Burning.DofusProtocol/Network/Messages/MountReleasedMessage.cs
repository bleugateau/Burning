using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountReleasedMessage : NetworkMessage
  {
    public const uint Id = 6308;
    public int mountId;

    public override uint MessageId
    {
      get
      {
        return 6308;
      }
    }

    public MountReleasedMessage()
    {
    }

    public MountReleasedMessage(int mountId)
    {
      this.mountId = mountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteVarInt(this.mountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mountId = reader.ReadVarInt();
    }
  }
}
