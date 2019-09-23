using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildModificationEmblemValidMessage : NetworkMessage
  {
    public const uint Id = 6328;
    public GuildEmblem guildEmblem;

    public override uint MessageId
    {
      get
      {
        return 6328;
      }
    }

    public GuildModificationEmblemValidMessage()
    {
    }

    public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
    {
      this.guildEmblem = guildEmblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.guildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildEmblem = new GuildEmblem();
      this.guildEmblem.Deserialize(reader);
    }
  }
}
