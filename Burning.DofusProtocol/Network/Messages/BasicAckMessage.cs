using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicAckMessage : NetworkMessage
  {
    public const uint Id = 6362;
    public uint seq;
    public uint lastPacketId;

    public override uint MessageId
    {
      get
      {
        return 6362;
      }
    }

    public BasicAckMessage()
    {
    }

    public BasicAckMessage(uint seq, uint lastPacketId)
    {
      this.seq = seq;
      this.lastPacketId = lastPacketId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.seq < 0U)
        throw new Exception("Forbidden value (" + (object) this.seq + ") on element seq.");
      writer.WriteVarInt((int) this.seq);
      if (this.lastPacketId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastPacketId + ") on element lastPacketId.");
      writer.WriteVarShort((short) this.lastPacketId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.seq = reader.ReadVarUhInt();
      if (this.seq < 0U)
        throw new Exception("Forbidden value (" + (object) this.seq + ") on element of BasicAckMessage.seq.");
      this.lastPacketId = (uint) reader.ReadVarUhShort();
      if (this.lastPacketId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastPacketId + ") on element of BasicAckMessage.lastPacketId.");
    }
  }
}
