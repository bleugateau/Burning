using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultAdditionalData
  {
    public const uint Id = 191;

    public virtual uint TypeId
    {
      get
      {
        return 191;
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
