using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachEnterMessage : NetworkMessage
  {
    public const uint Id = 6810;
    public double owner;

    public override uint MessageId
    {
      get
      {
        return 6810;
      }
    }

    public BreachEnterMessage()
    {
    }

    public BreachEnterMessage(double owner)
    {
      this.owner = owner;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.owner < 0.0 || this.owner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.owner + ") on element owner.");
      writer.WriteVarLong((long) this.owner);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.owner = (double) reader.ReadVarUhLong();
      if (this.owner < 0.0 || this.owner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.owner + ") on element of BreachEnterMessage.owner.");
    }
  }
}
