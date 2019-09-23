using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightSlideMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5525;
    public double targetId;
    public int startCellId;
    public int endCellId;

    public override uint MessageId
    {
      get
      {
        return 5525;
      }
    }

    public GameActionFightSlideMessage()
    {
    }

    public GameActionFightSlideMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int startCellId,
      int endCellId)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.startCellId = startCellId;
      this.endCellId = endCellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.startCellId < -1 || this.startCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.startCellId + ") on element startCellId.");
      writer.WriteShort((short) this.startCellId);
      if (this.endCellId < -1 || this.endCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.endCellId + ") on element endCellId.");
      writer.WriteShort((short) this.endCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightSlideMessage.targetId.");
      this.startCellId = (int) reader.ReadShort();
      if (this.startCellId < -1 || this.startCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.startCellId + ") on element of GameActionFightSlideMessage.startCellId.");
      this.endCellId = (int) reader.ReadShort();
      if (this.endCellId < -1 || this.endCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.endCellId + ") on element of GameActionFightSlideMessage.endCellId.");
    }
  }
}
