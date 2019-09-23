using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ServerSessionConstantString : ServerSessionConstant
  {
    public new const uint Id = 436;
    public string value;

    public override uint TypeId
    {
      get
      {
        return 436;
      }
    }

    public ServerSessionConstantString()
    {
    }

    public ServerSessionConstantString(uint id, string value)
      : base(id)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = reader.ReadUTF();
    }
  }
}
