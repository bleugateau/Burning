using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseGuildedInformations : HouseInstanceInformations
  {
    public new const uint Id = 512;
    public GuildInformations guildInfo;

    public override uint TypeId
    {
      get
      {
        return 512;
      }
    }

    public HouseGuildedInformations()
    {
    }

    public HouseGuildedInformations(
      uint instanceId,
      bool secondHand,
      bool isLocked,
      string ownerName,
      double price,
      bool isSaleLocked,
      GuildInformations guildInfo)
      : base(instanceId, secondHand, isLocked, ownerName, price, isSaleLocked)
    {
      this.guildInfo = guildInfo;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
    }
  }
}
