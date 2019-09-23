using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccountInformationsUpdateMessage : NetworkMessage
  {
    public const uint Id = 6740;
    public double subscriptionEndDate;
    public double unlimitedRestatEndDate;

    public override uint MessageId
    {
      get
      {
        return 6740;
      }
    }

    public AccountInformationsUpdateMessage()
    {
    }

    public AccountInformationsUpdateMessage(
      double subscriptionEndDate,
      double unlimitedRestatEndDate)
    {
      this.subscriptionEndDate = subscriptionEndDate;
      this.unlimitedRestatEndDate = unlimitedRestatEndDate;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subscriptionEndDate < 0.0 || this.subscriptionEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionEndDate + ") on element subscriptionEndDate.");
      writer.WriteDouble(this.subscriptionEndDate);
      if (this.unlimitedRestatEndDate < 0.0 || this.unlimitedRestatEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.unlimitedRestatEndDate + ") on element unlimitedRestatEndDate.");
      writer.WriteDouble(this.unlimitedRestatEndDate);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subscriptionEndDate = reader.ReadDouble();
      if (this.subscriptionEndDate < 0.0 || this.subscriptionEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.subscriptionEndDate + ") on element of AccountInformationsUpdateMessage.subscriptionEndDate.");
      this.unlimitedRestatEndDate = reader.ReadDouble();
      if (this.unlimitedRestatEndDate < 0.0 || this.unlimitedRestatEndDate > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.unlimitedRestatEndDate + ") on element of AccountInformationsUpdateMessage.unlimitedRestatEndDate.");
    }
  }
}
