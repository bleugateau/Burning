using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FinishMoveInformations
  {
    public const uint Id = 506;
    public uint finishMoveId;
    public bool finishMoveState;

    public virtual uint TypeId
    {
      get
      {
        return 506;
      }
    }

    public FinishMoveInformations()
    {
    }

    public FinishMoveInformations(uint finishMoveId, bool finishMoveState)
    {
      this.finishMoveId = finishMoveId;
      this.finishMoveState = finishMoveState;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.finishMoveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.finishMoveId + ") on element finishMoveId.");
      writer.WriteInt((int) this.finishMoveId);
      writer.WriteBoolean(this.finishMoveState);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.finishMoveId = (uint) reader.ReadInt();
      if (this.finishMoveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.finishMoveId + ") on element of FinishMoveInformations.finishMoveId.");
      this.finishMoveState = reader.ReadBoolean();
    }
  }
}
