using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightPlayersEnemiesListMessage : NetworkMessage
  {
    public List<CharacterMinimalPlusLookInformations> playerInfo = new List<CharacterMinimalPlusLookInformations>();
    public const uint Id = 5928;
    public double fightId;

    public override uint MessageId
    {
      get
      {
        return 5928;
      }
    }

    public GuildFightPlayersEnemiesListMessage()
    {
    }

    public GuildFightPlayersEnemiesListMessage(
      double fightId,
      List<CharacterMinimalPlusLookInformations> playerInfo)
    {
      this.fightId = fightId;
      this.playerInfo = playerInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteDouble(this.fightId);
      writer.WriteShort((short) this.playerInfo.Count);
      for (int index = 0; index < this.playerInfo.Count; ++index)
        this.playerInfo[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = reader.ReadDouble();
      if (this.fightId < 0.0 || this.fightId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GuildFightPlayersEnemiesListMessage.fightId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterMinimalPlusLookInformations lookInformations = new CharacterMinimalPlusLookInformations();
        lookInformations.Deserialize(reader);
        this.playerInfo.Add(lookInformations);
      }
    }
  }
}
