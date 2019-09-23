using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportHavenBagRequestMessage : NetworkMessage
  {
    public const uint Id = 6647;
    public double guestId;

    public override uint MessageId
    {
      get
      {
        return 6647;
      }
    }

    public TeleportHavenBagRequestMessage()
    {
    }

    public TeleportHavenBagRequestMessage(double guestId)
    {
      this.guestId = guestId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element guestId.");
      writer.WriteVarLong((long) this.guestId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guestId = (double) reader.ReadVarUhLong();
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element of TeleportHavenBagRequestMessage.guestId.");
    }
  }
}
