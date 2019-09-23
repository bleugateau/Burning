using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeOkMultiCraftMessage : NetworkMessage
  {
    public const uint Id = 5768;
    public double initiatorId;
    public double otherId;
    public int role;

    public override uint MessageId
    {
      get
      {
        return 5768;
      }
    }

    public ExchangeOkMultiCraftMessage()
    {
    }

    public ExchangeOkMultiCraftMessage(double initiatorId, double otherId, int role)
    {
      this.initiatorId = initiatorId;
      this.otherId = otherId;
      this.role = role;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.initiatorId < 0.0 || this.initiatorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.initiatorId + ") on element initiatorId.");
      writer.WriteVarLong((long) this.initiatorId);
      if (this.otherId < 0.0 || this.otherId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.otherId + ") on element otherId.");
      writer.WriteVarLong((long) this.otherId);
      writer.WriteByte((byte) this.role);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.initiatorId = (double) reader.ReadVarUhLong();
      if (this.initiatorId < 0.0 || this.initiatorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.initiatorId + ") on element of ExchangeOkMultiCraftMessage.initiatorId.");
      this.otherId = (double) reader.ReadVarUhLong();
      if (this.otherId < 0.0 || this.otherId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.otherId + ") on element of ExchangeOkMultiCraftMessage.otherId.");
      this.role = (int) reader.ReadByte();
    }
  }
}
