using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterStatsListMessage : NetworkMessage
  {
    public const uint Id = 500;
    public CharacterCharacteristicsInformations stats;

    public override uint MessageId
    {
      get
      {
        return 500;
      }
    }

    public CharacterStatsListMessage()
    {
    }

    public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
    {
      this.stats = stats;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.stats.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.stats = new CharacterCharacteristicsInformations();
      this.stats.Deserialize(reader);
    }
  }
}
