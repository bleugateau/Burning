using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorComplementaryInformations
  {
    public const uint Id = 448;

    public virtual uint TypeId
    {
      get
      {
        return 448;
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
