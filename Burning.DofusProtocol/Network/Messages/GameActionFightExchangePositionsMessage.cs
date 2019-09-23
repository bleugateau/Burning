using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5527;
    public double targetId;
    public int casterCellId;
    public int targetCellId;

    public override uint MessageId
    {
      get
      {
        return 5527;
      }
    }

    public GameActionFightExchangePositionsMessage()
    {
    }

    public GameActionFightExchangePositionsMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int casterCellId,
      int targetCellId)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.casterCellId = casterCellId;
      this.targetCellId = targetCellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.casterCellId < -1 || this.casterCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.casterCellId + ") on element casterCellId.");
      writer.WriteShort((short) this.casterCellId);
      if (this.targetCellId < -1 || this.targetCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element targetCellId.");
      writer.WriteShort((short) this.targetCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightExchangePositionsMessage.targetId.");
      this.casterCellId = (int) reader.ReadShort();
      if (this.casterCellId < -1 || this.casterCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.casterCellId + ") on element of GameActionFightExchangePositionsMessage.casterCellId.");
      this.targetCellId = (int) reader.ReadShort();
      if (this.targetCellId < -1 || this.targetCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element of GameActionFightExchangePositionsMessage.targetCellId.");
    }
  }
}
