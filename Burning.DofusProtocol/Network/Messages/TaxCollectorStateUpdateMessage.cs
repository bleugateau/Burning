using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorStateUpdateMessage : NetworkMessage
  {
    public const uint Id = 6455;
    public double uniqueId;
    public int state;

    public override uint MessageId
    {
      get
      {
        return 6455;
      }
    }

    public TaxCollectorStateUpdateMessage()
    {
    }

    public TaxCollectorStateUpdateMessage(double uniqueId, int state)
    {
      this.uniqueId = uniqueId;
      this.state = state;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.uniqueId < 0.0 || this.uniqueId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uniqueId + ") on element uniqueId.");
      writer.WriteDouble(this.uniqueId);
      writer.WriteByte((byte) this.state);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.uniqueId = reader.ReadDouble();
      if (this.uniqueId < 0.0 || this.uniqueId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.uniqueId + ") on element of TaxCollectorStateUpdateMessage.uniqueId.");
      this.state = (int) reader.ReadByte();
    }
  }
}
