using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class QuestObjectiveValidationMessage : NetworkMessage
  {
    public const uint Id = 6085;
    public uint questId;
    public uint objectiveId;

    public override uint MessageId
    {
      get
      {
        return 6085;
      }
    }

    public QuestObjectiveValidationMessage()
    {
    }

    public QuestObjectiveValidationMessage(uint questId, uint objectiveId)
    {
      this.questId = questId;
      this.objectiveId = objectiveId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element questId.");
      writer.WriteVarShort((short) this.questId);
      if (this.objectiveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectiveId + ") on element objectiveId.");
      writer.WriteVarShort((short) this.objectiveId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questId = (uint) reader.ReadVarUhShort();
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of QuestObjectiveValidationMessage.questId.");
      this.objectiveId = (uint) reader.ReadVarUhShort();
      if (this.objectiveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectiveId + ") on element of QuestObjectiveValidationMessage.objectiveId.");
    }
  }
}
