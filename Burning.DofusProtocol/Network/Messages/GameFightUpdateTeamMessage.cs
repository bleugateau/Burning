using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightUpdateTeamMessage : NetworkMessage
  {
    public const uint Id = 5572;
    public uint fightId;
    public FightTeamInformations team;

    public override uint MessageId
    {
      get
      {
        return 5572;
      }
    }

    public GameFightUpdateTeamMessage()
    {
    }

    public GameFightUpdateTeamMessage(uint fightId, FightTeamInformations team)
    {
      this.fightId = fightId;
      this.team = team;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      this.team.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameFightUpdateTeamMessage.fightId.");
      this.team = new FightTeamInformations();
      this.team.Deserialize(reader);
    }
  }
}
