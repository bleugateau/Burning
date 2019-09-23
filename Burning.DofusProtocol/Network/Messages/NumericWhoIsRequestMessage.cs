using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NumericWhoIsRequestMessage : NetworkMessage
  {
    public const uint Id = 6298;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 6298;
      }
    }

    public NumericWhoIsRequestMessage()
    {
    }

    public NumericWhoIsRequestMessage(double playerId)
    {
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of NumericWhoIsRequestMessage.playerId.");
    }
  }
}
