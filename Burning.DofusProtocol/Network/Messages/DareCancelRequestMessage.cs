using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareCancelRequestMessage : NetworkMessage
  {
    public const uint Id = 6680;
    public double dareId;

    public override uint MessageId
    {
      get
      {
        return 6680;
      }
    }

    public DareCancelRequestMessage()
    {
    }

    public DareCancelRequestMessage(double dareId)
    {
      this.dareId = dareId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareCancelRequestMessage.dareId.");
    }
  }
}
