using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class OnConnectionEventMessage : NetworkMessage
  {
    public const uint Id = 5726;
    public uint eventType;

    public override uint MessageId
    {
      get
      {
        return 5726;
      }
    }

    public OnConnectionEventMessage()
    {
    }

    public OnConnectionEventMessage(uint eventType)
    {
      this.eventType = eventType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.eventType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.eventType = (uint) reader.ReadByte();
      if (this.eventType < 0U)
        throw new Exception("Forbidden value (" + (object) this.eventType + ") on element of OnConnectionEventMessage.eventType.");
    }
  }
}
