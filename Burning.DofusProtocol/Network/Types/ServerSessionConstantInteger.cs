using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ServerSessionConstantInteger : ServerSessionConstant
  {
    public new const uint Id = 433;
    public int value;

    public override uint TypeId
    {
      get
      {
        return 433;
      }
    }

    public ServerSessionConstantInteger()
    {
    }

    public ServerSessionConstantInteger(uint id, int value)
      : base(id)
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
