using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ItemForPresetUpdateMessage : NetworkMessage
  {
    public const uint Id = 6760;
    public int presetId;
    public ItemForPreset presetItem;

    public override uint MessageId
    {
      get
      {
        return 6760;
      }
    }

    public ItemForPresetUpdateMessage()
    {
    }

    public ItemForPresetUpdateMessage(int presetId, ItemForPreset presetItem)
    {
      this.presetId = presetId;
      this.presetItem = presetItem;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetId);
      this.presetItem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.presetId = (int) reader.ReadShort();
      this.presetItem = new ItemForPreset();
      this.presetItem.Deserialize(reader);
    }
  }
}
