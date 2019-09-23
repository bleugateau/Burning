using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnResumeMessage : GameFightTurnStartMessage
  {
    public new const uint Id = 6307;
    public uint remainingTime;

    public override uint MessageId
    {
      get
      {
        return 6307;
      }
    }

    public GameFightTurnResumeMessage()
    {
    }

    public GameFightTurnResumeMessage(double id, uint waitTime, uint remainingTime)
      : base(id, waitTime)
    {
      this.remainingTime = remainingTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.remainingTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.remainingTime + ") on element remainingTime.");
      writer.WriteVarInt((int) this.remainingTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.remainingTime = reader.ReadVarUhInt();
      if (this.remainingTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.remainingTime + ") on element of GameFightTurnResumeMessage.remainingTime.");
    }
  }
}
