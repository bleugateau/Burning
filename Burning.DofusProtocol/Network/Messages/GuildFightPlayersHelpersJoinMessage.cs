using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
  {
    public const uint Id = 5720;
    public double fightId;
    public CharacterMinimalPlusLookInformations playerInfo;

    public override uint MessageId
    {
      get
      {
        return 5720;
      }
    }

    public GuildFightPlayersHelpersJoinMessage()
    {
    }

    public GuildFightPlayersHelpersJoinMessage(
      double fightId,
      CharacterMinimalPlusLookInformations playerInfo)
    {
      this.fightId = fightId;
      this.playerInfo = playerInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteDouble(this.fightId);
      this.playerInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = reader.ReadDouble();
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GuildFightPlayersHelpersJoinMessage.fightId.");
      this.playerInfo = new CharacterMinimalPlusLookInformations();
      this.playerInfo.Deserialize(reader);
    }
  }
}
