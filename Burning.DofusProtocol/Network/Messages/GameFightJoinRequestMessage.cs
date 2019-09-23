using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightJoinRequestMessage : NetworkMessage
  {
    public const uint Id = 701;
    public double fighterId;
    public uint fightId;

    public override uint MessageId
    {
      get
      {
        return 701;
      }
    }

    public GameFightJoinRequestMessage()
    {
    }

    public GameFightJoinRequestMessage(double fighterId, uint fightId)
    {
      this.fighterId = fighterId;
      this.fightId = fightId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fighterId < -9.00719925474099E+15 || this.fighterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterId + ") on element fighterId.");
      writer.WriteDouble(this.fighterId);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fighterId = reader.ReadDouble();
      if (this.fighterId < -9.00719925474099E+15 || this.fighterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.fighterId + ") on element of GameFightJoinRequestMessage.fighterId.");
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameFightJoinRequestMessage.fightId.");
    }
  }
}
