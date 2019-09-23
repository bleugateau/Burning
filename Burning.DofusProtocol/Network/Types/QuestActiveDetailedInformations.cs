using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class QuestActiveDetailedInformations : QuestActiveInformations
  {
    public List<QuestObjectiveInformations> objectives = new List<QuestObjectiveInformations>();
    public new const uint Id = 382;
    public uint stepId;

    public override uint TypeId
    {
      get
      {
        return 382;
      }
    }

    public QuestActiveDetailedInformations()
    {
    }

    public QuestActiveDetailedInformations(
      uint questId,
      uint stepId,
      List<QuestObjectiveInformations> objectives)
      : base(questId)
    {
      this.stepId = stepId;
      this.objectives = objectives;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.stepId < 0U)
        throw new Exception("Forbidden value (" + (object) this.stepId + ") on element stepId.");
      writer.WriteVarShort((short) this.stepId);
      writer.WriteShort((short) this.objectives.Count);
      for (int index = 0; index < this.objectives.Count; ++index)
      {
        writer.WriteShort((short) this.objectives[index].TypeId);
        this.objectives[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.stepId = (uint) reader.ReadVarUhShort();
      if (this.stepId < 0U)
        throw new Exception("Forbidden value (" + (object) this.stepId + ") on element of QuestActiveDetailedInformations.stepId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        QuestObjectiveInformations instance = ProtocolTypeManager.GetInstance<QuestObjectiveInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.objectives.Add(instance);
      }
    }
  }
}
