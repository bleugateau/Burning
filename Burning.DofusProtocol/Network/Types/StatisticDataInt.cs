using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticDataInt : StatisticData
  {
    public new const uint Id = 485;
    public int value;

    public override uint TypeId
    {
      get
      {
        return 485;
      }
    }

    public StatisticDataInt()
    {
    }

    public StatisticDataInt(int value)
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
