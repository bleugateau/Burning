using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class ScriptStoppedMessage : NetworkMessage
  {
    public const uint Id = 8002;

    public override uint MessageId
    {
      get
      {
        return 8002;
      }
    }

    public override void Deserialize(IDataReader reader)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
    }
  }
}
