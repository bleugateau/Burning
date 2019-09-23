using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterBuildPreset : PresetsContainerPreset
  {
    public new const uint Id = 534;
    public uint iconId;
    public string name;

    public override uint TypeId
    {
      get
      {
        return 534;
      }
    }

    public CharacterBuildPreset()
    {
    }

    public CharacterBuildPreset(int id, List<Preset> presets, uint iconId, string name)
      : base(id, presets)
    {
      this.iconId = iconId;
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element iconId.");
      writer.WriteShort((short) this.iconId);
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.iconId = (uint) reader.ReadShort();
      if (this.iconId < 0U)
        throw new Exception("Forbidden value (" + (object) this.iconId + ") on element of CharacterBuildPreset.iconId.");
      this.name = reader.ReadUTF();
    }
  }
}
