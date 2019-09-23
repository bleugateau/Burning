using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockGuildedInformations : PaddockBuyableInformations
  {
    public new const uint Id = 508;
    public bool deserted;
    public GuildInformations guildInfo;

    public override uint TypeId
    {
      get
      {
        return 508;
      }
    }

    public PaddockGuildedInformations()
    {
    }

    public PaddockGuildedInformations(
      double price,
      bool locked,
      bool deserted,
      GuildInformations guildInfo)
      : base(price, locked)
    {
      this.deserted = deserted;
      this.guildInfo = guildInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.deserted);
      this.guildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.deserted = reader.ReadBoolean();
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
    }
  }
}
