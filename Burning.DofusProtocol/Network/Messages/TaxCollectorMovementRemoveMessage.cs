using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorMovementRemoveMessage : NetworkMessage
  {
    public const uint Id = 5915;
    public double collectorId;

    public override uint MessageId
    {
      get
      {
        return 5915;
      }
    }

    public TaxCollectorMovementRemoveMessage()
    {
    }

    public TaxCollectorMovementRemoveMessage(double collectorId)
    {
      this.collectorId = collectorId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.collectorId < 0.0 || this.collectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.collectorId + ") on element collectorId.");
      writer.WriteDouble(this.collectorId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.collectorId = reader.ReadDouble();
      if (this.collectorId < 0.0 || this.collectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.collectorId + ") on element of TaxCollectorMovementRemoveMessage.collectorId.");
    }
  }
}
