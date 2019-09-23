using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class OpenHavenBagFurnitureSequenceRequestMessage : NetworkMessage
  {
    public const uint Id = 6635;

    public override uint MessageId
    {
      get
      {
        return 6635;
      }
    }

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
  }
}
