using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildHouseUpdateInformationMessage : NetworkMessage
  {
    public const uint Id = 6181;
    public HouseInformationsForGuild housesInformations;

    public override uint MessageId
    {
      get
      {
        return 6181;
      }
    }

    public GuildHouseUpdateInformationMessage()
    {
    }

    public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
    {
      this.housesInformations = housesInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.housesInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.housesInformations = new HouseInformationsForGuild();
      this.housesInformations.Deserialize(reader);
    }
  }
}
