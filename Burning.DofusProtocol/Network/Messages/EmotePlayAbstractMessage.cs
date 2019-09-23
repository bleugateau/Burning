using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EmotePlayAbstractMessage : NetworkMessage
  {
    public const uint Id = 5690;
    public uint emoteId;
    public double emoteStartTime;

    public override uint MessageId
    {
      get
      {
        return 5690;
      }
    }

    public EmotePlayAbstractMessage()
    {
    }

    public EmotePlayAbstractMessage(uint emoteId, double emoteStartTime)
    {
      this.emoteId = emoteId;
      this.emoteStartTime = emoteStartTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element emoteId.");
      writer.WriteByte((byte) this.emoteId);
      if (this.emoteStartTime < -9.00719925474099E+15 || this.emoteStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.emoteStartTime + ") on element emoteStartTime.");
      writer.WriteDouble(this.emoteStartTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.emoteId = (uint) reader.ReadByte();
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element of EmotePlayAbstractMessage.emoteId.");
      this.emoteStartTime = reader.ReadDouble();
      if (this.emoteStartTime < -9.00719925474099E+15 || this.emoteStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.emoteStartTime + ") on element of EmotePlayAbstractMessage.emoteStartTime.");
    }
  }
}
