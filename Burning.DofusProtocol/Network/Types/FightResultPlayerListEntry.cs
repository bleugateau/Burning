using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultPlayerListEntry : FightResultFighterListEntry
  {
    public List<FightResultAdditionalData> additional = new List<FightResultAdditionalData>();
    public new const uint Id = 24;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 24;
      }
    }

    public FightResultPlayerListEntry()
    {
    }

    public FightResultPlayerListEntry(
      uint outcome,
      uint wave,
      FightLoot rewards,
      double id,
      bool alive,
      uint level,
      List<FightResultAdditionalData> additional)
      : base(outcome, wave, rewards, id, alive)
    {
      this.level = level;
      this.additional = additional;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      writer.WriteShort((short) this.additional.Count);
      for (int index = 0; index < this.additional.Count; ++index)
      {
        writer.WriteShort((short) this.additional[index].TypeId);
        this.additional[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightResultPlayerListEntry.level.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        FightResultAdditionalData instance = ProtocolTypeManager.GetInstance<FightResultAdditionalData>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.additional.Add(instance);
      }
    }
  }
}
