using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StartupActionAddMessage : NetworkMessage
  {
    public const uint Id = 6538;
    public StartupActionAddObject newAction;

    public override uint MessageId
    {
      get
      {
        return 6538;
      }
    }

    public StartupActionAddMessage()
    {
    }

    public StartupActionAddMessage(StartupActionAddObject newAction)
    {
      this.newAction = newAction;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.newAction.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.newAction = new StartupActionAddObject();
      this.newAction.Deserialize(reader);
    }
  }
}
