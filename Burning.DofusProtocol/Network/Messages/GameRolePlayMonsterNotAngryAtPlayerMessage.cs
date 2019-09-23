using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayMonsterNotAngryAtPlayerMessage : NetworkMessage
  {
    public const uint Id = 6742;
    public double playerId;
    public double monsterGroupId;

    public override uint MessageId
    {
      get
      {
        return 6742;
      }
    }

    public GameRolePlayMonsterNotAngryAtPlayerMessage()
    {
    }

    public GameRolePlayMonsterNotAngryAtPlayerMessage(double playerId, double monsterGroupId)
    {
      this.playerId = playerId;
      this.monsterGroupId = monsterGroupId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element monsterGroupId.");
      writer.WriteDouble(this.monsterGroupId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of GameRolePlayMonsterNotAngryAtPlayerMessage.playerId.");
      this.monsterGroupId = reader.ReadDouble();
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element of GameRolePlayMonsterNotAngryAtPlayerMessage.monsterGroupId.");
    }
  }
}
