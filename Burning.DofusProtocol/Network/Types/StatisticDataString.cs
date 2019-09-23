using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticDataString : StatisticData
  {
    public new const uint Id = 487;
    public string value;

    public override uint TypeId
    {
      get
      {
        return 487;
      }
    }

    public StatisticDataString()
    {
    }

    public StatisticDataString(string value)
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
