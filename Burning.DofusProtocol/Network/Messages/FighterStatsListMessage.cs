using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FighterStatsListMessage : NetworkMessage
  {
    public const uint Id = 6322;
    public CharacterCharacteristicsInformations stats;

    public override uint MessageId
    {
      get
      {
        return 6322;
      }
    }

    public FighterStatsListMessage()
    {
    }

    public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
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
