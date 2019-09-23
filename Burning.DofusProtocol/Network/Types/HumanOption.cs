using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOption
  {
    public const uint Id = 406;

    public virtual uint TypeId
    {
      get
      {
        return 406;
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
