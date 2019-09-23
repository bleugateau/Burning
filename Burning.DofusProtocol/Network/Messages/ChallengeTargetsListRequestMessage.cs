using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeTargetsListRequestMessage : NetworkMessage
  {
    public const uint Id = 5614;
    public uint challengeId;

    public override uint MessageId
    {
      get
      {
        return 5614;
      }
    }

    public ChallengeTargetsListRequestMessage()
    {
    }

    public ChallengeTargetsListRequestMessage(uint challengeId)
    {
      this.challengeId = challengeId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element challengeId.");
      writer.WriteVarShort((short) this.challengeId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.challengeId = (uint) reader.ReadVarUhShort();
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element of ChallengeTargetsListRequestMessage.challengeId.");
    }
  }
}
