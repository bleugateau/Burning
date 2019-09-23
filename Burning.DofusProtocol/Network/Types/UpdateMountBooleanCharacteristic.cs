using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class UpdateMountBooleanCharacteristic : UpdateMountCharacteristic
  {
    public new const uint Id = 538;
    public bool value;

    public override uint TypeId
    {
      get
      {
        return 538;
      }
    }

    public UpdateMountBooleanCharacteristic()
    {
    }

    public UpdateMountBooleanCharacteristic(uint type, bool value)
      : base(type)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = reader.ReadBoolean();
    }
  }
}
