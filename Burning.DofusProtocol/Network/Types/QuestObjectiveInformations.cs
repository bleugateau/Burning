using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class QuestObjectiveInformations
  {
    public List<string> dialogParams = new List<string>();
    public const uint Id = 385;
    public uint objectiveId;
    public bool objectiveStatus;

    public virtual uint TypeId
    {
      get
      {
        return 385;
      }
    }

    public QuestObjectiveInformations()
    {
    }

    public QuestObjectiveInformations(
      uint objectiveId,
      bool objectiveStatus,
      List<string> dialogParams)
    {
      this.objectiveId = objectiveId;
      this.objectiveStatus = objectiveStatus;
      this.dialogParams = dialogParams;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.objectiveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectiveId + ") on element objectiveId.");
      writer.WriteVarShort((short) this.objectiveId);
      writer.WriteBoolean(this.objectiveStatus);
      writer.WriteShort((short) this.dialogParams.Count);
      for (int index = 0; index < this.dialogParams.Count; ++index)
        writer.WriteUTF(this.dialogParams[index]);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.objectiveId = (uint) reader.ReadVarUhShort();
      if (this.objectiveId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectiveId + ") on element of QuestObjectiveInformations.objectiveId.");
      this.objectiveStatus = reader.ReadBoolean();
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.dialogParams.Add(reader.ReadUTF());
    }
  }
}
