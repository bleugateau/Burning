using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class SpellsPreset : Preset
  {
    public List<SpellForPreset> spells = new List<SpellForPreset>();
    public new const uint Id = 519;

    public override uint TypeId
    {
      get
      {
        return 519;
      }
    }

    public SpellsPreset()
    {
    }

    public SpellsPreset(int id, List<SpellForPreset> spells)
      : base(id)
    {
      this.spells = spells;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.spells.Count);
      for (int index = 0; index < this.spells.Count; ++index)
        this.spells[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        SpellForPreset spellForPreset = new SpellForPreset();
        spellForPreset.Deserialize(reader);
        this.spells.Add(spellForPreset);
      }
    }
  }
}
