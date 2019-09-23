using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TitlesAndOrnamentsListRequestMessage : NetworkMessage
  {
    public const uint Id = 6363;

    public override uint MessageId
    {
      get
      {
        return 6363;
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
