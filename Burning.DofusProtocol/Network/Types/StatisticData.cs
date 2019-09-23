using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class StatisticData
  {
    public const uint Id = 484;

    public virtual uint TypeId
    {
      get
      {
        return 484;
      }
    }

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
  }
}
