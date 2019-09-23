using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EnterHavenBagRequestMessage : NetworkMessage
  {
    public const uint Id = 6636;
    public double havenBagOwner;

    public override uint MessageId
    {
      get
      {
        return 6636;
      }
    }

    public EnterHavenBagRequestMessage()
    {
    }

    public EnterHavenBagRequestMessage(double havenBagOwner)
    {
      this.havenBagOwner = havenBagOwner;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.havenBagOwner < 0.0 || this.havenBagOwner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.havenBagOwner + ") on element havenBagOwner.");
      writer.WriteVarLong((long) this.havenBagOwner);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.havenBagOwner = (double) reader.ReadVarUhLong();
      if (this.havenBagOwner < 0.0 || this.havenBagOwner > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.havenBagOwner + ") on element of EnterHavenBagRequestMessage.havenBagOwner.");
    }
  }
}
