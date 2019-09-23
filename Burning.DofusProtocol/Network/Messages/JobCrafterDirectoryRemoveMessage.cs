using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectoryRemoveMessage : NetworkMessage
  {
    public const uint Id = 5653;
    public uint jobId;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5653;
      }
    }

    public JobCrafterDirectoryRemoveMessage()
    {
    }

    public JobCrafterDirectoryRemoveMessage(uint jobId, double playerId)
    {
      this.jobId = jobId;
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobCrafterDirectoryRemoveMessage.jobId.");
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of JobCrafterDirectoryRemoveMessage.playerId.");
    }
  }
}
