using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
  {
    public new const uint Id = 5784;
    public double target;
    public uint skillId;

    public override uint MessageId
    {
      get
      {
        return 5784;
      }
    }

    public ExchangePlayerMultiCraftRequestMessage()
    {
    }

    public ExchangePlayerMultiCraftRequestMessage(int exchangeType, double target, uint skillId)
      : base(exchangeType)
    {
      this.target = target;
      this.skillId = skillId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element target.");
      writer.WriteVarLong((long) this.target);
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarInt((int) this.skillId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.target = (double) reader.ReadVarUhLong();
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element of ExchangePlayerMultiCraftRequestMessage.target.");
      this.skillId = reader.ReadVarUhInt();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of ExchangePlayerMultiCraftRequestMessage.skillId.");
    }
  }
}
