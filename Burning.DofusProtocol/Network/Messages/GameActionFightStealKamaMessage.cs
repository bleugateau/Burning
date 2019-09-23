using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightStealKamaMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5535;
    public double targetId;
    public double amount;

    public override uint MessageId
    {
      get
      {
        return 5535;
      }
    }

    public GameActionFightStealKamaMessage()
    {
    }

    public GameActionFightStealKamaMessage(
      uint actionId,
      double sourceId,
      double targetId,
      double amount)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.amount = amount;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.amount < 0.0 || this.amount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element amount.");
      writer.WriteVarLong((long) this.amount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightStealKamaMessage.targetId.");
      this.amount = (double) reader.ReadVarUhLong();
      if (this.amount < 0.0 || this.amount > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element of GameActionFightStealKamaMessage.amount.");
    }
  }
}
