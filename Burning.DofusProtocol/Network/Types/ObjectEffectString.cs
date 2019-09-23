using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectString : ObjectEffect
  {
    public new const uint Id = 74;
    public string value;

    public override uint TypeId
    {
      get
      {
        return 74;
      }
    }

    public ObjectEffectString()
    {
    }

    public ObjectEffectString(uint actionId, string value)
      : base(actionId)
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
