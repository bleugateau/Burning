using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DisplayNumericalValuePaddockMessage : NetworkMessage
  {
    public const uint Id = 6563;
    public int rideId;
    public int value;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6563;
      }
    }

    public DisplayNumericalValuePaddockMessage()
    {
    }

    public DisplayNumericalValuePaddockMessage(int rideId, int value, uint type)
    {
      this.rideId = rideId;
      this.value = value;
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.rideId);
      writer.WriteInt(this.value);
      writer.WriteByte((byte) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.rideId = reader.ReadInt();
      this.value = reader.ReadInt();
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of DisplayNumericalValuePaddockMessage.type.");
    }
  }
}
