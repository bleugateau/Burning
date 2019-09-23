using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayNpcQuestFlag
  {
    public List<uint> questsToValidId = new List<uint>();
    public List<uint> questsToStartId = new List<uint>();
    public const uint Id = 384;

    public virtual uint TypeId
    {
      get
      {
        return 384;
      }
    }

    public GameRolePlayNpcQuestFlag()
    {
    }

    public GameRolePlayNpcQuestFlag(List<uint> questsToValidId, List<uint> questsToStartId)
    {
      this.questsToValidId = questsToValidId;
      this.questsToStartId = questsToStartId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.questsToValidId.Count);
      for (int index = 0; index < this.questsToValidId.Count; ++index)
      {
        if (this.questsToValidId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.questsToValidId[index] + ") on element 1 (starting at 1) of questsToValidId.");
        writer.WriteVarShort((short) this.questsToValidId[index]);
      }
      writer.WriteShort((short) this.questsToStartId.Count);
      for (int index = 0; index < this.questsToStartId.Count; ++index)
      {
        if (this.questsToStartId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.questsToStartId[index] + ") on element 2 (starting at 1) of questsToStartId.");
        writer.WriteVarShort((short) this.questsToStartId[index]);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of questsToValidId.");
        this.questsToValidId.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of questsToStartId.");
        this.questsToStartId.Add(num2);
      }
    }
  }
}
