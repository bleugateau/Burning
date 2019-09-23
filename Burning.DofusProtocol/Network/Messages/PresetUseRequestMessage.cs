using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetUseRequestMessage : NetworkMessage
  {
    public const uint Id = 6759;
    public int presetId;

    public override uint MessageId
    {
      get
      {
        return 6759;
      }
    }

    public PresetUseRequestMessage()
    {
    }

    public PresetUseRequestMessage(int presetId)
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
