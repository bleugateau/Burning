using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SubscriptionZoneMessage : NetworkMessage
  {
    public const uint Id = 5573;
    public bool active;

    public override uint MessageId
    {
      get
      {
        return 5573;
      }
    }

    public SubscriptionZoneMessage()
    {
    }

    public SubscriptionZoneMessage(bool active)
    {
      this.active = active;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.active);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.active = reader.ReadBoolean();
    }
  }
}
