using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameCautiousMapMovementMessage : GameMapMovementMessage
  {
    public new const uint Id = 6497;

    public override uint MessageId
    {
      get
      {
        return 6497;
      }
    }

    public GameCautiousMapMovementMessage()
    {
    }

    public GameCautiousMapMovementMessage(
      List<uint> keyMovements,
      int forcedDirection,
      double actorId)
      : base(keyMovements, forcedDirection, actorId)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
