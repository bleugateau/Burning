using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightStartingMessage : NetworkMessage
  {
    public const uint Id = 700;
    public uint fightType;
    public uint fightId;
    public double attackerId;
    public double defenderId;

    public override uint MessageId
    {
      get
      {
        return 700;
      }
    }

    public GameFightStartingMessage()
    {
    }

    public GameFightStartingMessage(
      uint fightType,
      uint fightId,
      double attackerId,
      double defenderId)
    {
      this.fightType = fightType;
      this.fightId = fightId;
      this.attackerId = attackerId;
      this.defenderId = defenderId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.fightType);
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      if (this.attackerId < -9.00719925474099E+15 || this.attackerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackerId + ") on element attackerId.");
      writer.WriteDouble(this.attackerId);
      if (this.defenderId < -9.00719925474099E+15 || this.defenderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.defenderId + ") on element defenderId.");
      writer.WriteDouble(this.defenderId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightType = (uint) reader.ReadByte();
      if (this.fightType < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightType + ") on element of GameFightStartingMessage.fightType.");
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of GameFightStartingMessage.fightId.");
      this.attackerId = reader.ReadDouble();
      if (this.attackerId < -9.00719925474099E+15 || this.attackerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.attackerId + ") on element of GameFightStartingMessage.attackerId.");
      this.defenderId = reader.ReadDouble();
      if (this.defenderId < -9.00719925474099E+15 || this.defenderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.defenderId + ") on element of GameFightStartingMessage.defenderId.");
    }
  }
}
