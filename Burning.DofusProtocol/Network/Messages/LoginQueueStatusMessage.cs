using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LoginQueueStatusMessage : NetworkMessage
  {
    public const uint Id = 10;
    public uint position;
    public uint total;

    public override uint MessageId
    {
      get
      {
        return 10;
      }
    }

    public LoginQueueStatusMessage()
    {
    }

    public LoginQueueStatusMessage(uint position, uint total)
    {
      this.position = position;
      this.total = total;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.position < 0U || this.position > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.position + ") on element position.");
      writer.WriteShort((short) this.position);
      if (this.total < 0U || this.total > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.total + ") on element total.");
      writer.WriteShort((short) this.total);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.position = (uint) reader.ReadUShort();
      if (this.position < 0U || this.position > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.position + ") on element of LoginQueueStatusMessage.position.");
      this.total = (uint) reader.ReadUShort();
      if (this.total < 0U || this.total > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.total + ") on element of LoginQueueStatusMessage.total.");
    }
  }
}
