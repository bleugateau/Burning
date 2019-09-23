using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareCreatedMessage : NetworkMessage
  {
    public const uint Id = 6668;
    public DareInformations dareInfos;
    public bool needNotifications;

    public override uint MessageId
    {
      get
      {
        return 6668;
      }
    }

    public DareCreatedMessage()
    {
    }

    public DareCreatedMessage(DareInformations dareInfos, bool needNotifications)
    {
      this.dareInfos = dareInfos;
      this.needNotifications = needNotifications;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.dareInfos.Serialize(writer);
      writer.WriteBoolean(this.needNotifications);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dareInfos = new DareInformations();
      this.dareInfos.Deserialize(reader);
      this.needNotifications = reader.ReadBoolean();
    }
  }
}
