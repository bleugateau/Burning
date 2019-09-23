using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class UpdateMountIntegerCharacteristic : UpdateMountCharacteristic
  {
    public new const uint Id = 537;
    public int value;

    public override uint TypeId
    {
      get
      {
        return 537;
      }
    }

    public UpdateMountIntegerCharacteristic()
    {
    }

    public UpdateMountIntegerCharacteristic(uint type, int value)
      : base(type)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = reader.ReadInt();
    }
  }
}
