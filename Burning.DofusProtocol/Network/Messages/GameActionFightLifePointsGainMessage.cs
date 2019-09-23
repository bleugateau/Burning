using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6311;
    public double targetId;
    public uint delta;

    public override uint MessageId
    {
      get
      {
        return 6311;
      }
    }

    public GameActionFightLifePointsGainMessage()
    {
    }

    public GameActionFightLifePointsGainMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint delta)
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
      if (this.delta < 0U)
        throw new Exception("Forbidden value (" + (object) this.delta + ") on element delta.");
      writer.WriteVarInt((int) this.delta);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightLifePointsGainMessage.targetId.");
      this.delta = reader.ReadVarUhInt();
      if (this.delta < 0U)
        throw new Exception("Forbidden value (" + (object) this.delta + ") on element of GameActionFightLifePointsGainMessage.delta.");
    }
  }
}
