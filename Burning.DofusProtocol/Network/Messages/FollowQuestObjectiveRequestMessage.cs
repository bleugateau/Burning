using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FollowQuestObjectiveRequestMessage : NetworkMessage
  {
    public const uint Id = 6724;
    public uint questId;
    public int objectiveId;

    public override uint MessageId
    {
      get
      {
        return 6724;
      }
    }

    public FollowQuestObjectiveRequestMessage()
    {
    }

    public FollowQuestObjectiveRequestMessage(uint questId, int objectiveId)
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
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of FollowQuestObjectiveRequestMessage.questId.");
      this.objectiveId = (int) reader.ReadShort();
    }
  }
}
