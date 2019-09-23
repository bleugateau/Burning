using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
  {
    public new const uint Id = 6310;
    public uint shieldLoss;

    public override uint MessageId
    {
      get
      {
        return 6310;
      }
    }

    public GameActionFightLifeAndShieldPointsLostMessage()
    {
    }

    public GameActionFightLifeAndShieldPointsLostMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint loss,
      uint permanentDamages,
      int elementId,
      uint shieldLoss)
      : base(actionId, sourceId, targetId, loss, permanentDamages, elementId)
    {
      this.shieldLoss = shieldLoss;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.shieldLoss < 0U)
        throw new Exception("Forbidden value (" + (object) this.shieldLoss + ") on element shieldLoss.");
      writer.WriteVarShort((short) this.shieldLoss);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.shieldLoss = (uint) reader.ReadVarUhShort();
      if (this.shieldLoss < 0U)
        throw new Exception("Forbidden value (" + (object) this.shieldLoss + ") on element of GameActionFightLifeAndShieldPointsLostMessage.shieldLoss.");
    }
  }
}
