using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterCanBeCreatedResultMessage : NetworkMessage
  {
    public const uint Id = 6733;
    public bool yesYouCan;

    public override uint MessageId
    {
      get
      {
        return 6733;
      }
    }

    public CharacterCanBeCreatedResultMessage()
    {
    }

    public CharacterCanBeCreatedResultMessage(bool yesYouCan)
    {
      this.yesYouCan = yesYouCan;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.yesYouCan);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.yesYouCan = reader.ReadBoolean();
    }
  }
}
