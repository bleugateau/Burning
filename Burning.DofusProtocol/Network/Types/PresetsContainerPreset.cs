using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PresetsContainerPreset : Preset
  {
    public List<Preset> presets = new List<Preset>();
    public new const uint Id = 520;

    public override uint TypeId
    {
      get
      {
        return 520;
      }
    }

    public PresetsContainerPreset()
    {
    }

    public PresetsContainerPreset(int id, List<Preset> presets)
      : base(id)
    {
      this.presets = presets;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.presets.Count);
      for (int index = 0; index < this.presets.Count; ++index)
      {
        writer.WriteShort((short) this.presets[index].TypeId);
        this.presets[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        Preset instance = ProtocolTypeManager.GetInstance<Preset>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.presets.Add(instance);
      }
    }
  }
}
