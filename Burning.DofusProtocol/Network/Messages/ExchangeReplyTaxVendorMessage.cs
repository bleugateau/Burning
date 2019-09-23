using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeReplyTaxVendorMessage : NetworkMessage
  {
    public const uint Id = 5787;
    public double objectValue;
    public double totalTaxValue;

    public override uint MessageId
    {
      get
      {
        return 5787;
      }
    }

    public ExchangeReplyTaxVendorMessage()
    {
    }

    public ExchangeReplyTaxVendorMessage(double objectValue, double totalTaxValue)
    {
      this.objectValue = objectValue;
      this.totalTaxValue = totalTaxValue;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectValue < 0.0 || this.objectValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectValue + ") on element objectValue.");
      writer.WriteVarLong((long) this.objectValue);
      if (this.totalTaxValue < 0.0 || this.totalTaxValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.totalTaxValue + ") on element totalTaxValue.");
      writer.WriteVarLong((long) this.totalTaxValue);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectValue = (double) reader.ReadVarUhLong();
      if (this.objectValue < 0.0 || this.objectValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectValue + ") on element of ExchangeReplyTaxVendorMessage.objectValue.");
      this.totalTaxValue = (double) reader.ReadVarUhLong();
      if (this.totalTaxValue < 0.0 || this.totalTaxValue > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.totalTaxValue + ") on element of ExchangeReplyTaxVendorMessage.totalTaxValue.");
    }
  }
}
