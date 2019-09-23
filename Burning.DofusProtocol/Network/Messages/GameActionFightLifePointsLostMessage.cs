using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6312;
    public double targetId;
    public uint loss;
    public uint permanentDamages;
    public int elementId;

    public override uint MessageId
    {
      get
      {
        return 6312;
      }
    }

    public GameActionFightLifePointsLostMessage()
    {
    }

    public GameActionFightLifePointsLostMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint loss,
      uint permanentDamages,
      int elementId)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.loss = loss;
      this.permanentDamages = permanentDamages;
      this.elementId = elementId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.loss < 0U)
        throw new Exception("Forbidden value (" + (object) this.loss + ") on element loss.");
      writer.WriteVarInt((int) this.loss);
      if (this.permanentDamages < 0U)
        throw new Exception("Forbidden value (" + (object) this.permanentDamages + ") on element permanentDamages.");
      writer.WriteVarInt((int) this.permanentDamages);
      writer.WriteVarInt(this.elementId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightLifePointsLostMessage.targetId.");
      this.loss = reader.ReadVarUhInt();
      if (this.loss < 0U)
        throw new Exception("Forbidden value (" + (object) this.loss + ") on element of GameActionFightLifePointsLostMessage.loss.");
      this.permanentDamages = reader.ReadVarUhInt();
      if (this.permanentDamages < 0U)
        throw new Exception("Forbidden value (" + (object) this.permanentDamages + ") on element of GameActionFightLifePointsLostMessage.permanentDamages.");
      this.elementId = reader.ReadVarInt();
    }
  }
}
