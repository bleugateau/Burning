using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachKickRequestMessage : NetworkMessage
  {
    public const uint Id = 6804;
    public double target;

    public override uint MessageId
    {
      get
      {
        return 6804;
      }
    }

    public BreachKickRequestMessage()
    {
    }

    public BreachKickRequestMessage(double target)
    {
      this.target = target;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element target.");
      writer.WriteVarLong((long) this.target);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.target = (double) reader.ReadVarUhLong();
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element of BreachKickRequestMessage.target.");
    }
  }
}
