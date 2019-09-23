using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeInfoMessage : NetworkMessage
  {
    public const uint Id = 6022;
    public uint challengeId;
    public double targetId;
    public uint xpBonus;
    public uint dropBonus;

    public override uint MessageId
    {
      get
      {
        return 6022;
      }
    }

    public ChallengeInfoMessage()
    {
    }

    public ChallengeInfoMessage(uint challengeId, double targetId, uint xpBonus, uint dropBonus)
    {
      this.challengeId = challengeId;
      this.targetId = targetId;
      this.xpBonus = xpBonus;
      this.dropBonus = dropBonus;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element challengeId.");
      writer.WriteVarShort((short) this.challengeId);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.xpBonus < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBonus + ") on element xpBonus.");
      writer.WriteVarInt((int) this.xpBonus);
      if (this.dropBonus < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBonus + ") on element dropBonus.");
      writer.WriteVarInt((int) this.dropBonus);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.challengeId = (uint) reader.ReadVarUhShort();
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element of ChallengeInfoMessage.challengeId.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of ChallengeInfoMessage.targetId.");
      this.xpBonus = reader.ReadVarUhInt();
      if (this.xpBonus < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBonus + ") on element of ChallengeInfoMessage.xpBonus.");
      this.dropBonus = reader.ReadVarUhInt();
      if (this.dropBonus < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBonus + ") on element of ChallengeInfoMessage.dropBonus.");
    }
  }
}
