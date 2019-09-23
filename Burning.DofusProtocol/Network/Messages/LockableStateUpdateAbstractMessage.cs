using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableStateUpdateAbstractMessage : NetworkMessage
  {
    public const uint Id = 5671;
    public bool locked;

    public override uint MessageId
    {
      get
      {
        return 5671;
      }
    }

    public LockableStateUpdateAbstractMessage()
    {
    }

    public LockableStateUpdateAbstractMessage(bool locked)
    {
      this.locked = locked;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.locked);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.locked = reader.ReadBoolean();
    }
  }
}
