using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SelectedServerRefusedMessage : NetworkMessage
  {
    public const uint Id = 41;
    public uint serverId;
    public uint error;
    public uint serverStatus;

    public override uint MessageId
    {
      get
      {
        return 41;
      }
    }

    public SelectedServerRefusedMessage()
    {
    }

    public SelectedServerRefusedMessage(uint serverId, uint error, uint serverStatus)
    {
      this.serverId = serverId;
      this.error = error;
      this.serverStatus = serverStatus;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element serverId.");
      writer.WriteVarShort((short) this.serverId);
      writer.WriteByte((byte) this.error);
      writer.WriteByte((byte) this.serverStatus);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.serverId = (uint) reader.ReadVarUhShort();
      if (this.serverId < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverId + ") on element of SelectedServerRefusedMessage.serverId.");
      this.error = (uint) reader.ReadByte();
      if (this.error < 0U)
        throw new Exception("Forbidden value (" + (object) this.error + ") on element of SelectedServerRefusedMessage.error.");
      this.serverStatus = (uint) reader.ReadByte();
      if (this.serverStatus < 0U)
        throw new Exception("Forbidden value (" + (object) this.serverStatus + ") on element of SelectedServerRefusedMessage.serverStatus.");
    }
  }
}
