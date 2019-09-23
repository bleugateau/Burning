using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChallengeFightJoinRefusedMessage : NetworkMessage
  {
    public const uint Id = 5908;
    public double playerId;
    public int reason;

    public override uint MessageId
    {
      get
      {
        return 5908;
      }
    }

    public ChallengeFightJoinRefusedMessage()
    {
    }

    public ChallengeFightJoinRefusedMessage(double playerId, int reason)
    {
      this.playerId = playerId;
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of ChallengeFightJoinRefusedMessage.playerId.");
      this.reason = (int) reader.ReadByte();
    }
  }
}
