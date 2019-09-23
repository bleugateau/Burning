using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
  {
    public const uint Id = 6191;
    public double monsterGroupId;

    public override uint MessageId
    {
      get
      {
        return 6191;
      }
    }

    public GameRolePlayAttackMonsterRequestMessage()
    {
    }

    public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
    {
      this.monsterGroupId = monsterGroupId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element monsterGroupId.");
      writer.WriteDouble(this.monsterGroupId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.monsterGroupId = reader.ReadDouble();
      if (this.monsterGroupId < -9.00719925474099E+15 || this.monsterGroupId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.monsterGroupId + ") on element of GameRolePlayAttackMonsterRequestMessage.monsterGroupId.");
    }
  }
}
