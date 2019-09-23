using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayAggressionMessage : NetworkMessage
  {
    public const uint Id = 6073;
    public double attackerId;
    public double defenderId;

    public override uint MessageId
    {
      get
      {
        return 6073;
      }
    }

    public GameRolePlayAggressionMessage()
    {
    }

    public GameRolePlayAggressionMessage(double attackerId, double defenderId)
    {
      this.attackerId = attackerId;
      this.defenderId = defenderId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.attackerId < 0.0 || this.attackerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackerId + ") on element attackerId.");
      writer.WriteVarLong((long) this.attackerId);
      if (this.defenderId < 0.0 || this.defenderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.defenderId + ") on element defenderId.");
      writer.WriteVarLong((long) this.defenderId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.attackerId = (double) reader.ReadVarUhLong();
      if (this.attackerId < 0.0 || this.attackerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackerId + ") on element of GameRolePlayAggressionMessage.attackerId.");
      this.defenderId = (double) reader.ReadVarUhLong();
      if (this.defenderId < 0.0 || this.defenderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.defenderId + ") on element of GameRolePlayAggressionMessage.defenderId.");
    }
  }
}
