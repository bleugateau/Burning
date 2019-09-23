using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapChangeOrientationMessage : NetworkMessage
  {
    public const uint Id = 946;
    public ActorOrientation orientation;

    public override uint MessageId
    {
      get
      {
        return 946;
      }
    }

    public GameMapChangeOrientationMessage()
    {
    }

    public GameMapChangeOrientationMessage(ActorOrientation orientation)
    {
      this.orientation = orientation;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.orientation.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.orientation = new ActorOrientation();
      this.orientation.Deserialize(reader);
    }
  }
}
