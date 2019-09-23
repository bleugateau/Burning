using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnStartMessage : NetworkMessage
  {
    public const uint Id = 714;
    public double id;
    public uint waitTime;

    public override uint MessageId
    {
      get
      {
        return 714;
      }
    }

    public GameFightTurnStartMessage()
    {
    }

    public GameFightTurnStartMessage(double id, uint waitTime)
    {
      this.id = id;
      this.waitTime = waitTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      if (this.waitTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.waitTime + ") on element waitTime.");
      writer.WriteVarInt((int) this.waitTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameFightTurnStartMessage.id.");
      this.waitTime = reader.ReadVarUhInt();
      if (this.waitTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.waitTime + ") on element of GameFightTurnStartMessage.waitTime.");
    }
  }
}
