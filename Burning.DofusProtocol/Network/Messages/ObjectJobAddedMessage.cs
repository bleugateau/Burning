using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectJobAddedMessage : NetworkMessage
  {
    public const uint Id = 6014;
    public uint jobId;

    public override uint MessageId
    {
      get
      {
        return 6014;
      }
    }

    public ObjectJobAddedMessage()
    {
    }

    public ObjectJobAddedMessage(uint jobId)
    {
      this.jobId = jobId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of ObjectJobAddedMessage.jobId.");
    }
  }
}
