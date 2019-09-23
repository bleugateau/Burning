using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildKickRequestMessage : NetworkMessage
  {
    public const uint Id = 5887;
    public double kickedId;

    public override uint MessageId
    {
      get
      {
        return 5887;
      }
    }

    public GuildKickRequestMessage()
    {
    }

    public GuildKickRequestMessage(double kickedId)
    {
      this.kickedId = kickedId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.kickedId < 0.0 || this.kickedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kickedId + ") on element kickedId.");
      writer.WriteVarLong((long) this.kickedId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.kickedId = (double) reader.ReadVarUhLong();
      if (this.kickedId < 0.0 || this.kickedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kickedId + ") on element of GuildKickRequestMessage.kickedId.");
    }
  }
}
