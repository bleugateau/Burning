using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdentificationFailedBannedMessage : IdentificationFailedMessage
  {
    public new const uint Id = 6174;
    public double banEndDate;

    public override uint MessageId
    {
      get
      {
        return 6174;
      }
    }

    public IdentificationFailedBannedMessage()
    {
    }

    public IdentificationFailedBannedMessage(uint reason, double banEndDate)
      : base(reason)
    {
      this.banEndDate = banEndDate;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.banEndDate < 0.0 || this.banEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.banEndDate + ") on element banEndDate.");
      writer.WriteDouble(this.banEndDate);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.banEndDate = reader.ReadDouble();
      if (this.banEndDate < 0.0 || this.banEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.banEndDate + ") on element of IdentificationFailedBannedMessage.banEndDate.");
    }
  }
}
