using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextMoveMultipleElementsMessage : NetworkMessage
  {
    public List<EntityMovementInformations> movements = new List<EntityMovementInformations>();
    public const uint Id = 254;

    public override uint MessageId
    {
      get
      {
        return 254;
      }
    }

    public GameContextMoveMultipleElementsMessage()
    {
    }

    public GameContextMoveMultipleElementsMessage(List<EntityMovementInformations> movements)
    {
      this.movements = movements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.movements.Count);
      for (int index = 0; index < this.movements.Count; ++index)
        this.movements[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        EntityMovementInformations movementInformations = new EntityMovementInformations();
        movementInformations.Deserialize(reader);
        this.movements.Add(movementInformations);
      }
    }
  }
}
