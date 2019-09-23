using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SequenceEndMessage : NetworkMessage
  {
    public const uint Id = 956;
    public uint actionId;
    public double authorId;
    public int sequenceType;

    public override uint MessageId
    {
      get
      {
        return 956;
      }
    }

    public SequenceEndMessage()
    {
    }

    public SequenceEndMessage(uint actionId, double authorId, int sequenceType)
    {
      this.actionId = actionId;
      this.authorId = authorId;
      this.sequenceType = sequenceType;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteVarShort((short) this.actionId);
      if (this.authorId < -9.00719925474099E+15 || this.authorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.authorId + ") on element authorId.");
      writer.WriteDouble(this.authorId);
      writer.WriteByte((byte) this.sequenceType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.actionId = (uint) reader.ReadVarUhShort();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of SequenceEndMessage.actionId.");
      this.authorId = reader.ReadDouble();
      if (this.authorId < -9.00719925474099E+15 || this.authorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.authorId + ") on element of SequenceEndMessage.authorId.");
      this.sequenceType = (int) reader.ReadByte();
    }
  }
}
