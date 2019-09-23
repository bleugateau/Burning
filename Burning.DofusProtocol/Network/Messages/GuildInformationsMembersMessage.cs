using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInformationsMembersMessage : NetworkMessage
  {
    public List<GuildMember> members = new List<GuildMember>();
    public const uint Id = 5558;

    public override uint MessageId
    {
      get
      {
        return 5558;
      }
    }

    public GuildInformationsMembersMessage()
    {
    }

    public GuildInformationsMembersMessage(List<GuildMember> members)
    {
      this.members = members;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.members.Count);
      for (int index = 0; index < this.members.Count; ++index)
        this.members[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GuildMember guildMember = new GuildMember();
        guildMember.Deserialize(reader);
        this.members.Add(guildMember);
      }
    }
  }
}
