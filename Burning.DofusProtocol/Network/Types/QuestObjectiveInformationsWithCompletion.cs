using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
  {
    public new const uint Id = 386;
    public uint curCompletion;
    public uint maxCompletion;

    public override uint TypeId
    {
      get
      {
        return 386;
      }
    }

    public QuestObjectiveInformationsWithCompletion()
    {
    }

    public QuestObjectiveInformationsWithCompletion(
      uint objectiveId,
      bool objectiveStatus,
      List<string> dialogParams,
      uint curCompletion,
      uint maxCompletion)
      : base(objectiveId, objectiveStatus, dialogParams)
    {
      this.curCompletion = curCompletion;
      this.maxCompletion = maxCompletion;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.curCompletion < 0U)
        throw new Exception("Forbidden value (" + (object) this.curCompletion + ") on element curCompletion.");
      writer.WriteVarShort((short) this.curCompletion);
      if (this.maxCompletion < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxCompletion + ") on element maxCompletion.");
      writer.WriteVarShort((short) this.maxCompletion);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.curCompletion = (uint) reader.ReadVarUhShort();
      if (this.curCompletion < 0U)
        throw new Exception("Forbidden value (" + (object) this.curCompletion + ") on element of QuestObjectiveInformationsWithCompletion.curCompletion.");
      this.maxCompletion = (uint) reader.ReadVarUhShort();
      if (this.maxCompletion < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxCompletion + ") on element of QuestObjectiveInformationsWithCompletion.maxCompletion.");
    }
  }
}
