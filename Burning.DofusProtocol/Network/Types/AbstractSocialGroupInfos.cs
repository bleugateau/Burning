using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class AbstractSocialGroupInfos
  {
    public const uint Id = 416;

    public virtual uint TypeId
    {
      get
      {
        return 416;
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
