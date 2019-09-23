using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildListMessage : NetworkMessage
  {
    public List<GuildInformations> guilds = new List<GuildInformations>();
    public const uint Id = 6413;

    public override uint MessageId
    {
      get
      {
        return 6413;
      }
    }

    public GuildListMessage()
    {
    }

    public GuildListMessage(List<GuildInformations> guilds)
    {
      this.guilds = guilds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.guilds.Count);
      for (int index = 0; index < this.guilds.Count; ++index)
        this.guilds[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GuildInformations guildInformations = new GuildInformations();
        guildInformations.Deserialize(reader);
        this.guilds.Add(guildInformations);
      }
    }
  }
}
