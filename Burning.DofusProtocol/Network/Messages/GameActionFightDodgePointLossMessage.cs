using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5828;
    public double targetId;
    public uint amount;

    public override uint MessageId
    {
      get
      {
        return 5828;
      }
    }

    public GameActionFightDodgePointLossMessage()
    {
    }

    public GameActionFightDodgePointLossMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint amount)
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
      if (this.amount < 0U)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element amount.");
      writer.WriteVarShort((short) this.amount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightDodgePointLossMessage.targetId.");
      this.amount = (uint) reader.ReadVarUhShort();
      if (this.amount < 0U)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element of GameActionFightDodgePointLossMessage.amount.");
    }
  }
}
