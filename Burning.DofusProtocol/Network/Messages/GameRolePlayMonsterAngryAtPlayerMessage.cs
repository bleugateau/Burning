using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayMonsterAngryAtPlayerMessage : NetworkMessage
  {
    public const uint Id = 6741;
    public double playerId;
    public double monsterGroupId;
    public double angryStartTime;
    public double attackTime;

    public override uint MessageId
    {
      get
      {
        return 6741;
      }
    }

    public GameRolePlayMonsterAngryAtPlayerMessage()
    {
    }

    public GameRolePlayMonsterAngryAtPlayerMessage(
      double playerId,
      double monsterGroupId,
      double angryStartTime,
      double attackTime)
    {
      this.playerId = playerId;
      this.monsterGroupId = monsterGroupId;
      this.angryStartTime = angryStartTime;
      this.attackTime = attackTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element monsterGroupId.");
      writer.WriteDouble(this.monsterGroupId);
      if (this.angryStartTime < 0.0 || this.angryStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.angryStartTime + ") on element angryStartTime.");
      writer.WriteDouble(this.angryStartTime);
      if (this.attackTime < 0.0 || this.attackTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackTime + ") on element attackTime.");
      writer.WriteDouble(this.attackTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of GameRolePlayMonsterAngryAtPlayerMessage.playerId.");
      this.monsterGroupId = reader.ReadDouble();
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element of GameRolePlayMonsterAngryAtPlayerMessage.monsterGroupId.");
      this.angryStartTime = reader.ReadDouble();
      if (this.angryStartTime < 0.0 || this.angryStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.angryStartTime + ") on element of GameRolePlayMonsterAngryAtPlayerMessage.angryStartTime.");
      this.attackTime = reader.ReadDouble();
      if (this.attackTime < 0.0 || this.attackTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackTime + ") on element of GameRolePlayMonsterAngryAtPlayerMessage.attackTime.");
    }
  }
}
