using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DebugClearHighlightCellsMessage : NetworkMessage
  {
    public const uint Id = 2002;

    public override uint MessageId
    {
      get
      {
        return 2002;
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
