using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class ScriptStartedMessage : NetworkMessage
  {
    public const uint Id = 8001;

    public override uint MessageId
    {
      get
      {
        return 8001;
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
