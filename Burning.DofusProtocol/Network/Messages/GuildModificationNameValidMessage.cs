using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildModificationNameValidMessage : NetworkMessage
  {
    public const uint Id = 6327;
    public string guildName;

    public override uint MessageId
    {
      get
      {
        return 6327;
      }
    }

    public GuildModificationNameValidMessage()
    {
    }

    public GuildModificationNameValidMessage(string guildName)
    {
      this.guildName = guildName;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.guildName);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildName = reader.ReadUTF();
    }
  }
}
