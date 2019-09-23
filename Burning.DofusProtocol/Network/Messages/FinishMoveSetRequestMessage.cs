using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FinishMoveSetRequestMessage : NetworkMessage
  {
    public const uint Id = 6703;
    public uint finishMoveId;
    public bool finishMoveState;

    public override uint MessageId
    {
      get
      {
        return 6703;
      }
    }

    public FinishMoveSetRequestMessage()
    {
    }

    public FinishMoveSetRequestMessage(uint finishMoveId, bool finishMoveState)
    {
      this.finishMoveId = finishMoveId;
      this.finishMoveState = finishMoveState;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.finishMoveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.finishMoveId + ") on element finishMoveId.");
      writer.WriteInt((int) this.finishMoveId);
      writer.WriteBoolean(this.finishMoveState);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.finishMoveId = (uint) reader.ReadInt();
      if (this.finishMoveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.finishMoveId + ") on element of FinishMoveSetRequestMessage.finishMoveId.");
      this.finishMoveState = reader.ReadBoolean();
    }
  }
}
