using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountSetMessage : NetworkMessage
  {
    public const uint Id = 5968;
    public MountClientData mountData;

    public override uint MessageId
    {
      get
      {
        return 5968;
      }
    }

    public MountSetMessage()
    {
    }

    public MountSetMessage(MountClientData mountData)
    {
      this.mountData = mountData;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.mountData.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mountData = new MountClientData();
      this.mountData.Deserialize(reader);
    }
  }
}
