using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionEmote : HumanOption
  {
    public new const uint Id = 407;
    public uint emoteId;
    public double emoteStartTime;

    public override uint TypeId
    {
      get
      {
        return 407;
      }
    }

    public HumanOptionEmote()
    {
    }

    public HumanOptionEmote(uint emoteId, double emoteStartTime)
    {
      this.emoteId = emoteId;
      this.emoteStartTime = emoteStartTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element emoteId.");
      writer.WriteByte((byte) this.emoteId);
      if (this.emoteStartTime < -9.00719925474099E+15 || this.emoteStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.emoteStartTime + ") on element emoteStartTime.");
      writer.WriteDouble(this.emoteStartTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.emoteId = (uint) reader.ReadByte();
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element of HumanOptionEmote.emoteId.");
      this.emoteStartTime = reader.ReadDouble();
      if (this.emoteStartTime < -9.00719925474099E+15 || this.emoteStartTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.emoteStartTime + ") on element of HumanOptionEmote.emoteStartTime.");
    }
  }
}
