using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class UnfollowQuestObjectiveRequestMessage : NetworkMessage
  {
    public const uint Id = 6723;
    public uint questId;
    public int objectiveId;

    public override uint MessageId
    {
      get
      {
        return 6723;
      }
    }

    public UnfollowQuestObjectiveRequestMessage()
    {
    }

    public UnfollowQuestObjectiveRequestMessage(uint questId, int objectiveId)
    {
      this.questId = questId;
      this.objectiveId = objectiveId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element questId.");
      writer.WriteVarShort((short) this.questId);
      writer.WriteShort((short) this.objectiveId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questId = (uint) reader.ReadVarUhShort();
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of UnfollowQuestObjectiveRequestMessage.questId.");
      this.objectiveId = (int) reader.ReadShort();
    }
  }
}
