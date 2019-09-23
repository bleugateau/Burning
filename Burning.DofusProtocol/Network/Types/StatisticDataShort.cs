using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticDataShort : StatisticData
  {
    public new const uint Id = 488;
    public int value;

    public override uint TypeId
    {
      get
      {
        return 488;
      }
    }

    public StatisticDataShort()
    {
    }

    public StatisticDataShort(int value)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = (int) reader.ReadShort();
    }
  }
}
