using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildHousesInformationMessage : NetworkMessage
  {
    public List<HouseInformationsForGuild> housesInformations = new List<HouseInformationsForGuild>();
    public const uint Id = 5919;

    public override uint MessageId
    {
      get
      {
        return 5919;
      }
    }

    public GuildHousesInformationMessage()
    {
    }

    public GuildHousesInformationMessage(List<HouseInformationsForGuild> housesInformations)
    {
      this.housesInformations = housesInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.housesInformations.Count);
      for (int index = 0; index < this.housesInformations.Count; ++index)
        this.housesInformations[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        HouseInformationsForGuild informationsForGuild = new HouseInformationsForGuild();
        informationsForGuild.Deserialize(reader);
        this.housesInformations.Add(informationsForGuild);
      }
    }
  }
}
