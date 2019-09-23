using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
  {
    public const uint Id = 5772;
    public double humanVendorId;
    public uint humanVendorCell;

    public override uint MessageId
    {
      get
      {
        return 5772;
      }
    }

    public ExchangeOnHumanVendorRequestMessage()
    {
    }

    public ExchangeOnHumanVendorRequestMessage(double humanVendorId, uint humanVendorCell)
    {
      this.humanVendorId = humanVendorId;
      this.humanVendorCell = humanVendorCell;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.humanVendorId < 0.0 || this.humanVendorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.humanVendorId + ") on element humanVendorId.");
      writer.WriteVarLong((long) this.humanVendorId);
      if (this.humanVendorCell < 0U || this.humanVendorCell > 559U)
        throw new Exception("Forbidden value (" + (object) this.humanVendorCell + ") on element humanVendorCell.");
      writer.WriteVarShort((short) this.humanVendorCell);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.humanVendorId = (double) reader.ReadVarUhLong();
      if (this.humanVendorId < 0.0 || this.humanVendorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.humanVendorId + ") on element of ExchangeOnHumanVendorRequestMessage.humanVendorId.");
      this.humanVendorCell = (uint) reader.ReadVarUhShort();
      if (this.humanVendorCell < 0U || this.humanVendorCell > 559U)
        throw new Exception("Forbidden value (" + (object) this.humanVendorCell + ") on element of ExchangeOnHumanVendorRequestMessage.humanVendorCell.");
    }
  }
}
