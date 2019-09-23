using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class SpellForPreset
  {
    public List<int> shortcuts = new List<int>();
    public const uint Id = 557;
    public uint spellId;

    public virtual uint TypeId
    {
      get
      {
        return 557;
      }
    }

    public SpellForPreset()
    {
    }

    public SpellForPreset(uint spellId, List<int> shortcuts)
    {
      this.spellId = spellId;
      this.shortcuts = shortcuts;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      writer.WriteShort((short) this.shortcuts.Count);
      for (int index = 0; index < this.shortcuts.Count; ++index)
        writer.WriteShort((short) this.shortcuts[index]);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of SpellForPreset.spellId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.shortcuts.Add((int) reader.ReadShort());
    }
  }
}
