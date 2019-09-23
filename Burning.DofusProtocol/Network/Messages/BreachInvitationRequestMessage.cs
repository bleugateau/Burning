using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachInvitationRequestMessage : NetworkMessage
  {
    public const uint Id = 6794;
    public double guest;

    public override uint MessageId
    {
      get
      {
        return 6794;
      }
    }

    public BreachInvitationRequestMessage()
    {
    }

    public BreachInvitationRequestMessage(double guest)
    {
      this.guest = guest;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.guest < 0.0 || this.guest > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guest + ") on element guest.");
      writer.WriteVarLong((long) this.guest);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guest = (double) reader.ReadVarUhLong();
      if (this.guest < 0.0 || this.guest > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guest + ") on element of BreachInvitationRequestMessage.guest.");
    }
  }
}
