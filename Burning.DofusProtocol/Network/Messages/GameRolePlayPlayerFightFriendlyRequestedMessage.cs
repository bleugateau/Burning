using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayPlayerFightFriendlyRequestedMessage : NetworkMessage
  {
    public const uint Id = 5937;
    public uint fightId;
    public double sourceId;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 5937;
      }
    }

    public GameRolePlayPlayerFightFriendlyRequestedMessage()
    {
    }

    public GameRolePlayPlayerFightFriendlyRequestedMessage(
      uint fightId,
      double sourceId,
      double targetId)
    {
      this.fightId = fightId;
      this.sourceId = sourceId;
      this.targetId = targetId;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayPlayerFightFriendlyRequestedMessage.fightId.");
      this.sourceId = (double) reader.ReadVarUhLong();
      if (this.sourceId < 0.0 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of GameRolePlayPlayerFightFriendlyRequestedMessage.sourceId.");
      this.targetId = (double) reader.ReadVarUhLong();
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameRolePlayPlayerFightFriendlyRequestedMessage.targetId.");
    }
  }
}
