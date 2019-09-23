using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerSelectionMessage : NetworkMessage
  {
    public const uint Id = 40;
    public uint serverId;

    public override uint MessageId
    {
      get
      {
        return 40;
      }
    }

    public ServerSelectionMessage()
    {
    }

    public ServerSelectionMessage(uint serverId)
    {
      this.serverId = serverId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element serverId.");
      writer.WriteVarShort((short) this.serverId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.serverId = (uint) reader.ReadVarUhShort();
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element of ServerSelectionMessage.serverId.");
    }
  }
}
