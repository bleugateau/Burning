using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightRemoveTeamMemberMessage : NetworkMessage
  {
    public const uint Id = 711;
    public uint fightId;
    public uint teamId;
    public double charId;

    public override uint MessageId
    {
      get
      {
        return 711;
      }
    }

    public GameFightRemoveTeamMemberMessage()
    {
    }

    public GameFightRemoveTeamMemberMessage(uint fightId, uint teamId, double charId)
    {
      this.fightId = fightId;
      this.teamId = teamId;
      this.charId = charId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteByte((byte) this.teamId);
      if (this.charId < -9.00719925474099E+15 || this.charId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.charId + ") on element charId.");
      writer.WriteDouble(this.charId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameFightRemoveTeamMemberMessage.fightId.");
      this.teamId = (uint) reader.ReadByte();
      if (this.teamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.teamId + ") on element of GameFightRemoveTeamMemberMessage.teamId.");
      this.charId = reader.ReadDouble();
      if (this.charId < -9.00719925474099E+15 || this.charId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.charId + ") on element of GameFightRemoveTeamMemberMessage.charId.");
    }
  }
}
