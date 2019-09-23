using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetsMessage : NetworkMessage
  {
    public List<Preset> presets = new List<Preset>();
    public const uint Id = 6750;

    public override uint MessageId
    {
      get
      {
        return 6750;
      }
    }

    public PresetsMessage()
    {
    }

    public PresetsMessage(List<Preset> presets)
    {
      this.presets = presets;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presets.Count);
      for (int index = 0; index < this.presets.Count; ++index)
      {
        writer.WriteShort((short) this.presets[index].TypeId);
        this.presets[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
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
