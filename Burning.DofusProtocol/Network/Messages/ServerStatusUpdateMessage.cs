using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerStatusUpdateMessage : NetworkMessage
  {
    public const uint Id = 50;
    public GameServerInformations server;

    public override uint MessageId
    {
      get
      {
        return 50;
      }
    }

    public ServerStatusUpdateMessage()
    {
    }

    public ServerStatusUpdateMessage(GameServerInformations server)
    {
      this.server = server;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.server.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.server = new GameServerInformations();
      this.server.Deserialize(reader);
    }
  }
}
