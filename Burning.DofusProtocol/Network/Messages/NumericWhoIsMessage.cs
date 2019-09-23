using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NumericWhoIsMessage : NetworkMessage
  {
    public const uint Id = 6297;
    public double playerId;
    public uint accountId;

    public override uint MessageId
    {
      get
      {
        return 6297;
      }
    }

    public NumericWhoIsMessage()
    {
    }

    public NumericWhoIsMessage(double playerId, uint accountId)
    {
      this.playerId = playerId;
      this.accountId = accountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of NumericWhoIsMessage.playerId.");
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of NumericWhoIsMessage.accountId.");
    }
  }
}
