using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectErrorMessage : NetworkMessage
  {
    public const uint Id = 3004;
    public int reason;

    public override uint MessageId
    {
      get
      {
        return 3004;
      }
    }

    public ObjectErrorMessage()
    {
    }

    public ObjectErrorMessage(int reason)
    {
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.reason = (int) reader.ReadByte();
    }
  }
}
