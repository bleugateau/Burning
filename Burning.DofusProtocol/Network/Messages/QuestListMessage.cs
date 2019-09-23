using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class QuestListMessage : NetworkMessage
  {
    public List<uint> finishedQuestsIds = new List<uint>();
    public List<uint> finishedQuestsCounts = new List<uint>();
    public List<QuestActiveInformations> activeQuests = new List<QuestActiveInformations>();
    public List<uint> reinitDoneQuestsIds = new List<uint>();
    public const uint Id = 5626;

    public override uint MessageId
    {
      get
      {
        return 5626;
      }
    }

    public QuestListMessage()
    {
    }

    public QuestListMessage(
      List<uint> finishedQuestsIds,
      List<uint> finishedQuestsCounts,
      List<QuestActiveInformations> activeQuests,
      List<uint> reinitDoneQuestsIds)
    {
      this.finishedQuestsIds = finishedQuestsIds;
      this.finishedQuestsCounts = finishedQuestsCounts;
      this.activeQuests = activeQuests;
      this.reinitDoneQuestsIds = reinitDoneQuestsIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.finishedQuestsIds.Count);
      for (int index = 0; index < this.finishedQuestsIds.Count; ++index)
      {
        if (this.finishedQuestsIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.finishedQuestsIds[index] + ") on element 1 (starting at 1) of finishedQuestsIds.");
        writer.WriteVarShort((short) this.finishedQuestsIds[index]);
      }
      writer.WriteShort((short) this.finishedQuestsCounts.Count);
      for (int index = 0; index < this.finishedQuestsCounts.Count; ++index)
      {
        if (this.finishedQuestsCounts[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.finishedQuestsCounts[index] + ") on element 2 (starting at 1) of finishedQuestsCounts.");
        writer.WriteVarShort((short) this.finishedQuestsCounts[index]);
      }
      writer.WriteShort((short) this.activeQuests.Count);
      for (int index = 0; index < this.activeQuests.Count; ++index)
      {
        writer.WriteShort((short) this.activeQuests[index].TypeId);
        this.activeQuests[index].Serialize(writer);
      }
      writer.WriteShort((short) this.reinitDoneQuestsIds.Count);
      for (int index = 0; index < this.reinitDoneQuestsIds.Count; ++index)
      {
        if (this.reinitDoneQuestsIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.reinitDoneQuestsIds[index] + ") on element 4 (starting at 1) of reinitDoneQuestsIds.");
        writer.WriteVarShort((short) this.reinitDoneQuestsIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of finishedQuestsIds.");
        this.finishedQuestsIds.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of finishedQuestsCounts.");
        this.finishedQuestsCounts.Add(num2);
      }
      uint num4 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num4; ++index)
      {
        QuestActiveInformations instance = ProtocolTypeManager.GetInstance<QuestActiveInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.activeQuests.Add(instance);
      }
      uint num5 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num5; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of reinitDoneQuestsIds.");
        this.reinitDoneQuestsIds.Add(num2);
      }
    }
  }
}
