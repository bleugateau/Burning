using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareSubscribeRequestMessage : NetworkMessage
  {
    public const uint Id = 6666;
    public double dareId;
    public bool subscribe;

    public override uint MessageId
    {
      get
      {
        return 6666;
      }
    }

    public DareSubscribeRequestMessage()
    {
    }

    public DareSubscribeRequestMessage(double dareId, bool subscribe)
    {
      this.dareId = dareId;
      this.subscribe = subscribe;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element dareId.");
      writer.WriteDouble(this.dareId);
      writer.WriteBoolean(this.subscribe);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dareId = reader.ReadDouble();
      if (this.dareId < 0.0 || this.dareId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.dareId + ") on element of DareSubscribeRequestMessage.dareId.");
      this.subscribe = reader.ReadBoolean();
    }
  }
}
