using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SpouseStatusMessage : NetworkMessage
  {
    public const uint Id = 6265;
    public bool hasSpouse;

    public override uint MessageId
    {
      get
      {
        return 6265;
      }
    }

    public SpouseStatusMessage()
    {
    }

    public SpouseStatusMessage(bool hasSpouse)
    {
      this.hasSpouse = hasSpouse;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.hasSpouse);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hasSpouse = reader.ReadBoolean();
    }
  }
}
