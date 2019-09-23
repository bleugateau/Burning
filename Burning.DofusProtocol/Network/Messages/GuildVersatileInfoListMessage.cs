using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildVersatileInfoListMessage : NetworkMessage
  {
    public List<GuildVersatileInformations> guilds = new List<GuildVersatileInformations>();
    public const uint Id = 6435;

    public override uint MessageId
    {
      get
      {
        return 6435;
      }
    }

    public GuildVersatileInfoListMessage()
    {
    }

    public GuildVersatileInfoListMessage(List<GuildVersatileInformations> guilds)
    {
      this.guilds = guilds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.guilds.Count);
      for (int index = 0; index < this.guilds.Count; ++index)
      {
        writer.WriteShort((short) this.guilds[index].TypeId);
        this.guilds[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GuildVersatileInformations instance = ProtocolTypeManager.GetInstance<GuildVersatileInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.guilds.Add(instance);
      }
    }
  }
}
