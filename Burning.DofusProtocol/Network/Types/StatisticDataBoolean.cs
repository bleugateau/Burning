using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticDataBoolean : StatisticData
  {
    public new const uint Id = 482;
    public bool value;

    public override uint TypeId
    {
      get
      {
        return 482;
      }
    }

    public StatisticDataBoolean()
    {
    }

    public StatisticDataBoolean(bool value)
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
