using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetDeleteRequestMessage : NetworkMessage
  {
    public const uint Id = 6755;
    public int presetId;

    public override uint MessageId
    {
      get
      {
        return 6755;
      }
    }

    public PresetDeleteRequestMessage()
    {
    }

    public PresetDeleteRequestMessage(int presetId)
    {
      this.presetId = presetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.presetId = (int) reader.ReadShort();
    }
  }
}
