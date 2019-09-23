using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetSavedMessage : NetworkMessage
  {
    public const uint Id = 6763;
    public int presetId;
    public Preset preset;

    public override uint MessageId
    {
      get
      {
        return 6763;
      }
    }

    public PresetSavedMessage()
    {
    }

    public PresetSavedMessage(int presetId, Preset preset)
    {
      this.presetId = presetId;
      this.preset = preset;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetId);
      writer.WriteShort((short) this.preset.TypeId);
      this.preset.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.presetId = (int) reader.ReadShort();
      this.preset = ProtocolTypeManager.GetInstance<Preset>((uint) reader.ReadUShort());
      this.preset.Deserialize(reader);
    }
  }
}
