using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChangeHavenBagRoomRequestMessage : NetworkMessage
  {
    public const uint Id = 6638;
    public uint roomId;

    public override uint MessageId
    {
      get
      {
        return 6638;
      }
    }

    public ChangeHavenBagRoomRequestMessage()
    {
    }

    public ChangeHavenBagRoomRequestMessage(uint roomId)
    {
      this.roomId = roomId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.roomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.roomId + ") on element roomId.");
      writer.WriteByte((byte) this.roomId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.roomId = (uint) reader.ReadByte();
      if (this.roomId < 0U)
        throw new Exception("Forbidden value (" + (object) this.roomId + ") on element of ChangeHavenBagRoomRequestMessage.roomId.");
    }
  }
}
