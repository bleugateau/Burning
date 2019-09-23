using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachTeleportResponseMessage : NetworkMessage
  {
    public const uint Id = 6816;
    public bool teleported;

    public override uint MessageId
    {
      get
      {
        return 6816;
      }
    }

    public BreachTeleportResponseMessage()
    {
    }

    public BreachTeleportResponseMessage(bool teleported)
    {
      this.teleported = teleported;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.teleported);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.teleported = reader.ReadBoolean();
    }
  }
}
