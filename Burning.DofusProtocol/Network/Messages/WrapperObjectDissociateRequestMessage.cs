using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class WrapperObjectDissociateRequestMessage : NetworkMessage
  {
    public const uint Id = 6524;
    public uint hostUID;
    public uint hostPos;

    public override uint MessageId
    {
      get
      {
        return 6524;
      }
    }

    public WrapperObjectDissociateRequestMessage()
    {
    }

    public WrapperObjectDissociateRequestMessage(uint hostUID, uint hostPos)
    {
      this.hostUID = hostUID;
      this.hostPos = hostPos;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element hostUID.");
      writer.WriteVarInt((int) this.hostUID);
      if (this.hostPos < 0U || this.hostPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hostPos + ") on element hostPos.");
      writer.WriteByte((byte) this.hostPos);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hostUID = reader.ReadVarUhInt();
      if (this.hostUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.hostUID + ") on element of WrapperObjectDissociateRequestMessage.hostUID.");
      this.hostPos = (uint) reader.ReadByte();
      if (this.hostPos < 0U || this.hostPos > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hostPos + ") on element of WrapperObjectDissociateRequestMessage.hostPos.");
    }
  }
}
