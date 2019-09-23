using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuestModeMessage : NetworkMessage
  {
    public const uint Id = 6505;
    public bool active;

    public override uint MessageId
    {
      get
      {
        return 6505;
      }
    }

    public GuestModeMessage()
    {
    }

    public GuestModeMessage(bool active)
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
