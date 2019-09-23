using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class QuestStepStartedMessage : NetworkMessage
  {
    public const uint Id = 6096;
    public uint questId;
    public uint stepId;

    public override uint MessageId
    {
      get
      {
        return 6096;
      }
    }

    public QuestStepStartedMessage()
    {
    }

    public QuestStepStartedMessage(uint questId, uint stepId)
    {
      this.questId = questId;
      this.stepId = stepId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element questId.");
      writer.WriteVarShort((short) this.questId);
      if (this.stepId < 0U)
        throw new Exception("Forbidden value (" + (object) this.stepId + ") on element stepId.");
      writer.WriteVarShort((short) this.stepId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questId = (uint) reader.ReadVarUhShort();
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of QuestStepStartedMessage.questId.");
      this.stepId = (uint) reader.ReadVarUhShort();
      if (this.stepId < 0U)
        throw new Exception("Forbidden value (" + (object) this.stepId + ") on element of QuestStepStartedMessage.stepId.");
    }
  }
}
