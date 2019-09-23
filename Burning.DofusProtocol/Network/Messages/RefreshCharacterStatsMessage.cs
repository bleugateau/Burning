using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class RefreshCharacterStatsMessage : NetworkMessage
  {
    public const uint Id = 6699;
    public double fighterId;
    public GameFightMinimalStats stats;

    public override uint MessageId
    {
      get
      {
        return 6699;
      }
    }

    public RefreshCharacterStatsMessage()
    {
    }

    public RefreshCharacterStatsMessage(double fighterId, GameFightMinimalStats stats)
    {
      this.fighterId = fighterId;
      this.stats = stats;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fighterId < -9.00719925474099E+15 || this.fighterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterId + ") on element fighterId.");
      writer.WriteDouble(this.fighterId);
      this.stats.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fighterId = reader.ReadDouble();
      if (this.fighterId < -9.00719925474099E+15 || this.fighterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterId + ") on element of RefreshCharacterStatsMessage.fighterId.");
      this.stats = new GameFightMinimalStats();
      this.stats.Deserialize(reader);
    }
  }
}
