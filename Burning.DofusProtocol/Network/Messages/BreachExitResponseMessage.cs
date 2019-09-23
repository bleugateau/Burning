using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachExitResponseMessage : NetworkMessage
  {
    public const uint Id = 6814;
    public bool exited;

    public override uint MessageId
    {
      get
      {
        return 6814;
      }
    }

    public BreachExitResponseMessage()
    {
    }

    public BreachExitResponseMessage(bool exited)
    {
      this.exited = exited;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.exited);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.exited = reader.ReadBoolean();
    }
  }
}
