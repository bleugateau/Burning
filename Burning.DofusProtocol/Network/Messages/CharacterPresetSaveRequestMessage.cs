using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterPresetSaveRequestMessage : PresetSaveRequestMessage
  {
    public new const uint Id = 6756;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 6756;
      }
    }

    public CharacterPresetSaveRequestMessage()
    {
    }

    public CharacterPresetSaveRequestMessage(
      int presetId,
      uint symbolId,
      bool updateData,
      string name)
      : base(presetId, symbolId, updateData)
    {
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
    }
  }
}
