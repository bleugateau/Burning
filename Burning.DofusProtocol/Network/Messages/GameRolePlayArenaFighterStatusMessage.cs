using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
  {
    public const uint Id = 6281;
    public uint fightId;
    public double playerId;
    public bool accepted;

    public override uint MessageId
    {
      get
      {
        return 6281;
      }
    }

    public GameRolePlayArenaFighterStatusMessage()
    {
    }

    public GameRolePlayArenaFighterStatusMessage(uint fightId, double playerId, bool accepted)
    {
      this.fightId = fightId;
      this.playerId = playerId;
      this.accepted = accepted;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      if (this.playerId < -9.00719925474099E+15 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteDouble(this.playerId);
      writer.WriteBoolean(this.accepted);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameRolePlayArenaFighterStatusMessage.fightId.");
      this.playerId = reader.ReadDouble();
      if (this.playerId < -9.00719925474099E+15 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of GameRolePlayArenaFighterStatusMessage.playerId.");
      this.accepted = reader.ReadBoolean();
    }
  }
}
