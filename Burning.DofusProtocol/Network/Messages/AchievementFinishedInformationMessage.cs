using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementFinishedInformationMessage : AchievementFinishedMessage
  {
    public new const uint Id = 6381;
    public string name;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 6381;
      }
    }

    public AchievementFinishedInformationMessage()
    {
    }

    public AchievementFinishedInformationMessage(
      AchievementAchievedRewardable achievement,
      string name,
      double playerId)
      : base(achievement)
    {
      this.name = name;
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of AchievementFinishedInformationMessage.playerId.");
    }
  }
}
