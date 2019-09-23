using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FinishMoveListMessage : NetworkMessage
  {
    public List<FinishMoveInformations> finishMoves = new List<FinishMoveInformations>();
    public const uint Id = 6704;

    public override uint MessageId
    {
      get
      {
        return 6704;
      }
    }

    public FinishMoveListMessage()
    {
    }

    public FinishMoveListMessage(List<FinishMoveInformations> finishMoves)
    {
      this.finishMoves = finishMoves;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.finishMoves.Count);
      for (int index = 0; index < this.finishMoves.Count; ++index)
        this.finishMoves[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        FinishMoveInformations moveInformations = new FinishMoveInformations();
        moveInformations.Deserialize(reader);
        this.finishMoves.Add(moveInformations);
      }
    }
  }
}
