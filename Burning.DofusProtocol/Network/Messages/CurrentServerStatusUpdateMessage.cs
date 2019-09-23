using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CurrentServerStatusUpdateMessage : NetworkMessage
  {
    public const uint Id = 6525;
    public uint status;

    public override uint MessageId
    {
      get
      {
        return 6525;
      }
    }

    public CurrentServerStatusUpdateMessage()
    {
    }

    public CurrentServerStatusUpdateMessage(uint status)
    {
      this.status = status;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.status);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.status = (uint) reader.ReadByte();
      if (this.status < 0U)
        throw new Exception("Forbidden value (" + (object) this.status + ") on element of CurrentServerStatusUpdateMessage.status.");
    }
  }
}
