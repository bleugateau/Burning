using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayPlayerFightFriendlyAnsweredMessage : NetworkMessage
  {
    public const uint Id = 5733;
    public uint fightId;
    public double sourceId;
    public double targetId;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 5733;
      }
    }

    public GameRolePlayPlayerFightFriendlyAnsweredMessage()
    {
    }

    public GameRolePlayPlayerFightFriendlyAnsweredMessage(
      uint fightId,
      double sourceId,
      double targetId,
      bool accept)
    {
      this.fightId = fightId;
      this.sourceId = sourceId;
      this.targetId = targetId;
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      if (this.sourceId < 0.0 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element sourceId.");
      writer.WriteVarLong((long) this.sourceId);
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteVarLong((long) this.targetId);
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayPlayerFightFriendlyAnsweredMessage.fightId.");
      this.sourceId = (double) reader.ReadVarUhLong();
      if (this.sourceId < 0.0 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of GameRolePlayPlayerFightFriendlyAnsweredMessage.sourceId.");
      this.targetId = (double) reader.ReadVarUhLong();
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameRolePlayPlayerFightFriendlyAnsweredMessage.targetId.");
      this.accept = reader.ReadBoolean();
    }
  }
}
