using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AnomalyStateMessage : NetworkMessage
  {
    public const uint Id = 6831;
    public uint subAreaId;
    public bool open;
    public double closingTime;

    public override uint MessageId
    {
      get
      {
        return 6831;
      }
    }

    public AnomalyStateMessage()
    {
    }

    public AnomalyStateMessage(uint subAreaId, bool open, double closingTime)
    {
      this.subAreaId = subAreaId;
      this.open = open;
      this.closingTime = closingTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteBoolean(this.open);
      if (this.closingTime < 0.0 || this.closingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.closingTime + ") on element closingTime.");
      writer.WriteVarLong((long) this.closingTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of AnomalyStateMessage.subAreaId.");
      this.open = reader.ReadBoolean();
      this.closingTime = (double) reader.ReadVarUhLong();
      if (this.closingTime < 0.0 || this.closingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.closingTime + ") on element of AnomalyStateMessage.closingTime.");
    }
  }
}
