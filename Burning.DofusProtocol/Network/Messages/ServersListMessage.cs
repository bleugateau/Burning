using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServersListMessage : NetworkMessage
  {
    public List<GameServerInformations> servers = new List<GameServerInformations>();
    public const uint Id = 30;
    public uint alreadyConnectedToServerId;
    public bool canCreateNewCharacter;

    public override uint MessageId
    {
      get
      {
        return 30;
      }
    }

    public ServersListMessage()
    {
    }

    public ServersListMessage(
      List<GameServerInformations> servers,
      uint alreadyConnectedToServerId,
      bool canCreateNewCharacter)
    {
      this.servers = servers;
      this.alreadyConnectedToServerId = alreadyConnectedToServerId;
      this.canCreateNewCharacter = canCreateNewCharacter;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.servers.Count);
      for (int index = 0; index < this.servers.Count; ++index)
        this.servers[index].Serialize(writer);
      if (this.alreadyConnectedToServerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.alreadyConnectedToServerId + ") on element alreadyConnectedToServerId.");
      writer.WriteVarShort((short) this.alreadyConnectedToServerId);
      writer.WriteBoolean(this.canCreateNewCharacter);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameServerInformations serverInformations = new GameServerInformations();
        serverInformations.Deserialize(reader);
        this.servers.Add(serverInformations);
      }
      this.alreadyConnectedToServerId = (uint) reader.ReadVarUhShort();
      if (this.alreadyConnectedToServerId < 0U)
        throw new Exception("Forbidden value (" + (object) this.alreadyConnectedToServerId + ") on element of ServersListMessage.alreadyConnectedToServerId.");
      this.canCreateNewCharacter = reader.ReadBoolean();
    }
  }
}
