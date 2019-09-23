using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
  {
    public List<GameServerInformations> servers = new List<GameServerInformations>();
    public new const uint Id = 6469;

    public override uint MessageId
    {
      get
      {
        return 6469;
      }
    }

    public SelectedServerDataExtendedMessage()
    {
    }

    public SelectedServerDataExtendedMessage(
      uint serverId,
      string address,
      List<uint> ports,
      bool canCreateNewCharacter,
      List<int> ticket,
      List<GameServerInformations> servers)
      : base(serverId, address, ports, canCreateNewCharacter, ticket)
    {
      this.servers = servers;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.servers.Count);
      for (int index = 0; index < this.servers.Count; ++index)
        this.servers[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameServerInformations serverInformations = new GameServerInformations();
        serverInformations.Deserialize(reader);
        this.servers.Add(serverInformations);
      }
    }
  }
}
