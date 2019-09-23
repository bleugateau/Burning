using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachSaveBoughtMessage : NetworkMessage
  {
    public const uint Id = 6788;
    public bool bought;

    public override uint MessageId
    {
      get
      {
        return 6788;
      }
    }

    public BreachSaveBoughtMessage()
    {
    }

    public BreachSaveBoughtMessage(bool bought)
    {
      this.bought = bought;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.bought);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.bought = reader.ReadBoolean();
    }
  }
}
