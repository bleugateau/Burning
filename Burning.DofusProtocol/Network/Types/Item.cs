using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class Item
  {
    public const uint Id = 7;

    public virtual uint TypeId
    {
      get
      {
        return 7;
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
