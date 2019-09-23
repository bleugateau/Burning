using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterSelectedSuccessMessage : NetworkMessage
  {
    public const uint Id = 153;
    public CharacterBaseInformations infos;
    public bool isCollectingStats;

    public override uint MessageId
    {
      get
      {
        return 153;
      }
    }

    public CharacterSelectedSuccessMessage()
    {
    }

    public CharacterSelectedSuccessMessage(CharacterBaseInformations infos, bool isCollectingStats)
    {
      this.infos = infos;
      this.isCollectingStats = isCollectingStats;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.infos.Serialize(writer);
      writer.WriteBoolean(this.isCollectingStats);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.infos = new CharacterBaseInformations();
      this.infos.Deserialize(reader);
      this.isCollectingStats = reader.ReadBoolean();
    }
  }
}
