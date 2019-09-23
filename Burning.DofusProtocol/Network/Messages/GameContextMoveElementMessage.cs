using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextMoveElementMessage : NetworkMessage
  {
    public const uint Id = 253;
    public EntityMovementInformations movement;

    public override uint MessageId
    {
      get
      {
        return 253;
      }
    }

    public GameContextMoveElementMessage()
    {
    }

    public GameContextMoveElementMessage(EntityMovementInformations movement)
    {
      this.movement = movement;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.movement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.movement = new EntityMovementInformations();
      this.movement.Deserialize(reader);
    }
  }
}
