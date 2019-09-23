using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
  {
    public new const uint Id = 446;
    public BasicGuildInformations guild;

    public override uint TypeId
    {
      get
      {
        return 446;
      }
    }

    public TaxCollectorGuildInformations()
    {
    }

    public TaxCollectorGuildInformations(BasicGuildInformations guild)
    {
      this.guild = guild;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guild = new BasicGuildInformations();
      this.guild.Deserialize(reader);
    }
  }
}
