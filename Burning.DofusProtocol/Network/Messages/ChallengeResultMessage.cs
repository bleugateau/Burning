using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeResultMessage : NetworkMessage
  {
    public const uint Id = 6019;
    public uint challengeId;
    public bool success;

    public override uint MessageId
    {
      get
      {
        return 6019;
      }
    }

    public ChallengeResultMessage()
    {
    }

    public ChallengeResultMessage(uint challengeId, bool success)
    {
      this.challengeId = challengeId;
      this.success = success;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element challengeId.");
      writer.WriteVarShort((short) this.challengeId);
      writer.WriteBoolean(this.success);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.challengeId = (uint) reader.ReadVarUhShort();
      if (this.challengeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.challengeId + ") on element of ChallengeResultMessage.challengeId.");
      this.success = reader.ReadBoolean();
    }
  }
}
