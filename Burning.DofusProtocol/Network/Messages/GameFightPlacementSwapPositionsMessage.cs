using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightPlacementSwapPositionsMessage : NetworkMessage
  {
    public List<IdentifiedEntityDispositionInformations> dispositions = new List<IdentifiedEntityDispositionInformations>();
    public const uint Id = 6544;

    public override uint MessageId
    {
      get
      {
        return 6544;
      }
    }

    public GameFightPlacementSwapPositionsMessage()
    {
    }

    public GameFightPlacementSwapPositionsMessage(
      List<IdentifiedEntityDispositionInformations> dispositions)
    {
      this.dispositions = dispositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      for (int index = 0; index < 2; ++index)
        this.dispositions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      for (int index = 0; index < 2; ++index)
      {
        this.dispositions[index] = new IdentifiedEntityDispositionInformations();
        this.dispositions[index].Deserialize(reader);
      }
    }
  }
}
