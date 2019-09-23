using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticDataByte : StatisticData
  {
    public new const uint Id = 486;
    public int value;

    public override uint TypeId
    {
      get
      {
        return 486;
      }
    }

    public StatisticDataByte()
    {
    }

    public StatisticDataByte(int value)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = (int) reader.ReadByte();
    }
  }
}
