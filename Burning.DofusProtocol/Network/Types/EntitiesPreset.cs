using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class EntitiesPreset : Preset
  {
    public List<uint> entityIds = new List<uint>();
    public new const uint Id = 545;
    public uint iconId;

    public override uint TypeId
    {
      get
      {
        return 545;
      }
    }

    public EntitiesPreset()
    {
    }

    public EntitiesPreset(int id, uint iconId, List<uint> entityIds)
      : base(id)
    {
      this.iconId = iconId;
      this.entityIds = entityIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element iconId.");
      writer.WriteShort((short) this.iconId);
      writer.WriteShort((short) this.entityIds.Count);
      for (int index = 0; index < this.entityIds.Count; ++index)
      {
        if (this.entityIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.entityIds[index] + ") on element 2 (starting at 1) of entityIds.");
        writer.WriteVarShort((short) this.entityIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.iconId = (uint) reader.ReadShort();
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element of EntitiesPreset.iconId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of entityIds.");
        this.entityIds.Add(num2);
      }
    }
  }
}
