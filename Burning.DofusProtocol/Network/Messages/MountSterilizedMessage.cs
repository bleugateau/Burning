using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountSterilizedMessage : NetworkMessage
  {
    public const uint Id = 5977;
    public int mountId;

    public override uint MessageId
    {
      get
      {
        return 5977;
      }
    }

    public MountSterilizedMessage()
    {
    }

    public MountSterilizedMessage(int mountId)
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
