using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StartupActionsExecuteMessage : NetworkMessage
  {
    public const uint Id = 1302;

    public override uint MessageId
    {
      get
      {
        return 1302;
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
