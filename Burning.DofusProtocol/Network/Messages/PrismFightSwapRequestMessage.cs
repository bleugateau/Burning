using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismFightSwapRequestMessage : NetworkMessage
  {
    public const uint Id = 5901;
    public uint subAreaId;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 5901;
      }
    }

    public PrismFightSwapRequestMessage()
    {
    }

    public PrismFightSwapRequestMessage(uint subAreaId, double targetId)
    {
      this.subAreaId = subAreaId;
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteVarLong((long) this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismFightSwapRequestMessage.subAreaId.");
      this.targetId = (double) reader.ReadVarUhLong();
      if (this.targetId < 0.0 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of PrismFightSwapRequestMessage.targetId.");
    }
  }
}
