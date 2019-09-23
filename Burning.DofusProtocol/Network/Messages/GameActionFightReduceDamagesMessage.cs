using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5526;
    public double targetId;
    public uint amount;

    public override uint MessageId
    {
      get
      {
        return 5526;
      }
    }

    public GameActionFightReduceDamagesMessage()
    {
    }

    public GameActionFightReduceDamagesMessage(
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
      writer.WriteVarInt((int) this.amount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightReduceDamagesMessage.targetId.");
      this.amount = reader.ReadVarUhInt();
      if (this.amount < 0U)
        throw new Exception("Forbidden value (" + (object) this.amount + ") on element of GameActionFightReduceDamagesMessage.amount.");
    }
  }
}
