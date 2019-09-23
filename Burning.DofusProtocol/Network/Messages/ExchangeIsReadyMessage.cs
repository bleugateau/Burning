using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeIsReadyMessage : NetworkMessage
  {
    public const uint Id = 5509;
    public double id;
    public bool ready;

    public override uint MessageId
    {
      get
      {
        return 5509;
      }
    }

    public ExchangeIsReadyMessage()
    {
    }

    public ExchangeIsReadyMessage(double id, bool ready)
    {
      this.id = id;
      this.ready = ready;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      writer.WriteBoolean(this.ready);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of ExchangeIsReadyMessage.id.");
      this.ready = reader.ReadBoolean();
    }
  }
}
