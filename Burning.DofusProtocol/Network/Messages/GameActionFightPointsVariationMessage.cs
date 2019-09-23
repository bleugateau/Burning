using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
  {
    public new const uint Id = 1030;
    public double targetId;
    public int delta;

    public override uint MessageId
    {
      get
      {
        return 1030;
      }
    }

    public GameActionFightPointsVariationMessage()
    {
    }

    public GameActionFightPointsVariationMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int delta)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.delta = delta;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      writer.WriteShort((short) this.delta);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightPointsVariationMessage.targetId.");
      this.delta = (int) reader.ReadShort();
    }
  }
}
