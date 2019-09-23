using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class IdolsPreset : Preset
  {
    public List<uint> idolIds = new List<uint>();
    public new const uint Id = 491;
    public uint iconId;

    public override uint TypeId
    {
      get
      {
        return 491;
      }
    }

    public IdolsPreset()
    {
    }

    public IdolsPreset(int id, uint iconId, List<uint> idolIds)
      : base(id)
    {
      this.iconId = iconId;
      this.idolIds = idolIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element iconId.");
      writer.WriteShort((short) this.iconId);
      writer.WriteShort((short) this.idolIds.Count);
      for (int index = 0; index < this.idolIds.Count; ++index)
      {
        if (this.idolIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.idolIds[index] + ") on element 2 (starting at 1) of idolIds.");
        writer.WriteVarShort((short) this.idolIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.iconId = (uint) reader.ReadShort();
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element of IdolsPreset.iconId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of idolIds.");
        this.idolIds.Add(num2);
      }
    }
  }
}
