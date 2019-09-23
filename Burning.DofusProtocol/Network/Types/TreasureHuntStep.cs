using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TreasureHuntStep
  {
    public const uint Id = 463;

    public virtual uint TypeId
    {
      get
      {
        return 463;
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
