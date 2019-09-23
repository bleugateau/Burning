using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachSavedMessage : NetworkMessage
  {
    public const uint Id = 6798;
    public bool saved;

    public override uint MessageId
    {
      get
      {
        return 6798;
      }
    }

    public BreachSavedMessage()
    {
    }

    public BreachSavedMessage(bool saved)
    {
      this.saved = saved;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.saved);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.saved = reader.ReadBoolean();
    }
  }
}
