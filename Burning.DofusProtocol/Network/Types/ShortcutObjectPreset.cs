using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutObjectPreset : ShortcutObject
  {
    public new const uint Id = 370;
    public int presetId;

    public override uint TypeId
    {
      get
      {
        return 370;
      }
    }

    public ShortcutObjectPreset()
    {
    }

    public ShortcutObjectPreset(uint slot, int presetId)
      : base(slot)
    {
      this.presetId = presetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.presetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.presetId = (int) reader.ReadShort();
    }
  }
}
