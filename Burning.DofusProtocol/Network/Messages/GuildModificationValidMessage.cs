using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildModificationValidMessage : NetworkMessage
  {
    public const uint Id = 6323;
    public string guildName;
    public GuildEmblem guildEmblem;

    public override uint MessageId
    {
      get
      {
        return 6323;
      }
    }

    public GuildModificationValidMessage()
    {
    }

    public GuildModificationValidMessage(string guildName, GuildEmblem guildEmblem)
    {
      this.guildName = guildName;
      this.guildEmblem = guildEmblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.guildName);
      this.guildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildName = reader.ReadUTF();
      this.guildEmblem = new GuildEmblem();
      this.guildEmblem.Deserialize(reader);
    }
  }
}
