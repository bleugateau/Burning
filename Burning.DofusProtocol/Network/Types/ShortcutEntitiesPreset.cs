using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutEntitiesPreset : Shortcut
  {
    public new const uint Id = 544;
    public int presetId;

    public override uint TypeId
    {
      get
      {
        return 544;
      }
    }

    public ShortcutEntitiesPreset()
    {
    }

    public ShortcutEntitiesPreset(uint slot, int presetId)
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
