using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeTargetUpdateMessage : NetworkMessage
  {
    public const uint Id = 6123;
    public uint challengeId;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 6123;
      }
    }

    public ChallengeTargetUpdateMessage()
    {
    }

    public ChallengeTargetUpdateMessage(uint challengeId, double targetId)
    {
      this.challengeId = challengeId;
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element challengeId.");
      writer.WriteVarShort((short) this.challengeId);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.challengeId = (uint) reader.ReadVarUhShort();
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element of ChallengeTargetUpdateMessage.challengeId.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of ChallengeTargetUpdateMessage.targetId.");
    }
  }
}
