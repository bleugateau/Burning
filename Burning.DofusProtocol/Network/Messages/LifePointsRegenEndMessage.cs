using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LifePointsRegenEndMessage : UpdateLifePointsMessage
  {
    public new const uint Id = 5686;
    public uint lifePointsGained;

    public override uint MessageId
    {
      get
      {
        return 5686;
      }
    }

    public LifePointsRegenEndMessage()
    {
    }

    public LifePointsRegenEndMessage(uint lifePoints, uint maxLifePoints, uint lifePointsGained)
      : base(lifePoints, maxLifePoints)
    {
      this.lifePointsGained = lifePointsGained;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.lifePointsGained < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePointsGained + ") on element lifePointsGained.");
      writer.WriteVarInt((int) this.lifePointsGained);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.lifePointsGained = reader.ReadVarUhInt();
      if (this.lifePointsGained < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePointsGained + ") on element of LifePointsRegenEndMessage.lifePointsGained.");
    }
  }
}
