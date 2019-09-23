using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolsPresetSaveRequestMessage : PresetSaveRequestMessage
  {
    public new const uint Id = 6758;

    public override uint MessageId
    {
      get
      {
        return 6758;
      }
    }

    public IdolsPresetSaveRequestMessage()
    {
    }

    public IdolsPresetSaveRequestMessage(int presetId, uint symbolId, bool updateData)
      : base(presetId, symbolId, updateData)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
