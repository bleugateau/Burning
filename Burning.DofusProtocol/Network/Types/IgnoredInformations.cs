using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class IgnoredInformations : AbstractContactInformations
  {
    public new const uint Id = 106;

    public override uint TypeId
    {
      get
      {
        return 106;
      }
    }

    public IgnoredInformations()
    {
    }

    public IgnoredInformations(uint accountId, string accountName)
      : base(accountId, accountName)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
