using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class RoomAvailableUpdateMessage : NetworkMessage
  {
    public const uint Id = 6630;
    public uint nbRoom;

    public override uint MessageId
    {
      get
      {
        return 6630;
      }
    }

    public RoomAvailableUpdateMessage()
    {
    }

    public RoomAvailableUpdateMessage(uint nbRoom)
    {
      this.nbRoom = nbRoom;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.nbRoom < 0U || this.nbRoom > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.nbRoom + ") on element nbRoom.");
      writer.WriteByte((byte) this.nbRoom);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.nbRoom = (uint) reader.ReadByte();
      if (this.nbRoom < 0U || this.nbRoom > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.nbRoom + ") on element of RoomAvailableUpdateMessage.nbRoom.");
    }
  }
}
