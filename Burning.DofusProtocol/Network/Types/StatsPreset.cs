using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatsPreset : Preset
  {
    public List<SimpleCharacterCharacteristicForPreset> stats = new List<SimpleCharacterCharacteristicForPreset>();
    public new const uint Id = 521;

    public override uint TypeId
    {
      get
      {
        return 521;
      }
    }

    public StatsPreset()
    {
    }

    public StatsPreset(int id, List<SimpleCharacterCharacteristicForPreset> stats)
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
        SimpleCharacterCharacteristicForPreset characteristicForPreset = new SimpleCharacterCharacteristicForPreset();
        characteristicForPreset.Deserialize(reader);
        this.stats.Add(characteristicForPreset);
      }
    }
  }
}
