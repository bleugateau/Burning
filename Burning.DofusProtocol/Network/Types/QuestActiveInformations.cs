using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class QuestActiveInformations
  {
    public const uint Id = 381;
    public uint questId;

    public virtual uint TypeId
    {
      get
      {
        return 381;
      }
    }

    public QuestActiveInformations()
    {
    }

    public QuestActiveInformations(uint questId)
    {
      this.questId = questId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element questId.");
      writer.WriteVarShort((short) this.questId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.questId = (uint) reader.ReadVarUhShort();
      if (this.questId < 0U)
        throw new Exception("Forbidden value (" + (object) this.questId + ") on element of QuestActiveInformations.questId.");
    }
  }
}
