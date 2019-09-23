using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceModificationEmblemValidMessage : NetworkMessage
  {
    public const uint Id = 6447;
    public GuildEmblem Alliancemblem;

    public override uint MessageId
    {
      get
      {
        return 6447;
      }
    }

    public AllianceModificationEmblemValidMessage()
    {
    }

    public AllianceModificationEmblemValidMessage(GuildEmblem Alliancemblem)
    {
      this.Alliancemblem = Alliancemblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.Alliancemblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.Alliancemblem = new GuildEmblem();
      this.Alliancemblem.Deserialize(reader);
    }
  }
}
