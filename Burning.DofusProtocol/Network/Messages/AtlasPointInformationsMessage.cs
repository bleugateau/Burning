using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AtlasPointInformationsMessage : NetworkMessage
  {
    public const uint Id = 5956;
    public AtlasPointsInformations type;

    public override uint MessageId
    {
      get
      {
        return 5956;
      }
    }

    public AtlasPointInformationsMessage()
    {
    }

    public AtlasPointInformationsMessage(AtlasPointsInformations type)
    {
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.type.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.type = new AtlasPointsInformations();
      this.type.Deserialize(reader);
    }
  }
}
