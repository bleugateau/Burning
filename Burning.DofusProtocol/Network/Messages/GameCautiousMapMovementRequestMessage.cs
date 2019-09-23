using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage
  {
    public new const uint Id = 6496;

    public override uint MessageId
    {
      get
      {
        return 6496;
      }
    }

    public GameCautiousMapMovementRequestMessage()
    {
    }

    public GameCautiousMapMovementRequestMessage(List<uint> keyMovements, double mapId)
      : base(keyMovements, mapId)
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
