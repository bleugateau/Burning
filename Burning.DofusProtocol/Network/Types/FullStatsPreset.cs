using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FullStatsPreset : Preset
  {
    public List<CharacterCharacteristicForPreset> stats = new List<CharacterCharacteristicForPreset>();
    public new const uint Id = 532;

    public override uint TypeId
    {
      get
      {
        return 532;
      }
    }

    public FullStatsPreset()
    {
    }

    public FullStatsPreset(int id, List<CharacterCharacteristicForPreset> stats)
      : base(id)
    {
      this.stats = stats;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.stats.Count);
      for (int index = 0; index < this.stats.Count; ++index)
        this.stats[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterCharacteristicForPreset characteristicForPreset = new CharacterCharacteristicForPreset();
        characteristicForPreset.Deserialize(reader);
        this.stats.Add(characteristicForPreset);
      }
    }
  }
}
