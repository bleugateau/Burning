using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class UpdateLifePointsMessage : NetworkMessage
  {
    public const uint Id = 5658;
    public uint lifePoints;
    public uint maxLifePoints;

    public override uint MessageId
    {
      get
      {
        return 5658;
      }
    }

    public UpdateLifePointsMessage()
    {
    }

    public UpdateLifePointsMessage(uint lifePoints, uint maxLifePoints)
    {
      this.lifePoints = lifePoints;
      this.maxLifePoints = maxLifePoints;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element lifePoints.");
      writer.WriteVarInt((int) this.lifePoints);
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element maxLifePoints.");
      writer.WriteVarInt((int) this.maxLifePoints);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.lifePoints = reader.ReadVarUhInt();
      if (this.lifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.lifePoints + ") on element of UpdateLifePointsMessage.lifePoints.");
      this.maxLifePoints = reader.ReadVarUhInt();
      if (this.maxLifePoints < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxLifePoints + ") on element of UpdateLifePointsMessage.maxLifePoints.");
    }
  }
}
