using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SequenceStartMessage : NetworkMessage
  {
    public const uint Id = 955;
    public int sequenceType;
    public double authorId;

    public override uint MessageId
    {
      get
      {
        return 955;
      }
    }

    public SequenceStartMessage()
    {
    }

    public SequenceStartMessage(int sequenceType, double authorId)
    {
      this.sequenceType = sequenceType;
      this.authorId = authorId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.sequenceType);
      if (this.authorId < -9.00719925474099E+15 || this.authorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.authorId + ") on element authorId.");
      writer.WriteDouble(this.authorId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.sequenceType = (int) reader.ReadByte();
      this.authorId = reader.ReadDouble();
      if (this.authorId < -9.00719925474099E+15 || this.authorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.authorId + ") on element of SequenceStartMessage.authorId.");
    }
  }
}
