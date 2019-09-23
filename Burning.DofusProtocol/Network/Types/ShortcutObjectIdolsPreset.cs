using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutObjectIdolsPreset : ShortcutObject
  {
    public new const uint Id = 492;
    public int presetId;

    public override uint TypeId
    {
      get
      {
        return 492;
      }
    }

    public ShortcutObjectIdolsPreset()
    {
    }

    public ShortcutObjectIdolsPreset(uint slot, int presetId)
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
