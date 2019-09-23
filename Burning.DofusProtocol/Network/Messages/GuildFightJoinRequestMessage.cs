using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightJoinRequestMessage : NetworkMessage
  {
    public const uint Id = 5717;
    public double taxCollectorId;

    public override uint MessageId
    {
      get
      {
        return 5717;
      }
    }

    public GuildFightJoinRequestMessage()
    {
    }

    public GuildFightJoinRequestMessage(double taxCollectorId)
    {
      this.taxCollectorId = taxCollectorId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.taxCollectorId < 0.0 || this.taxCollectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorId + ") on element taxCollectorId.");
      writer.WriteDouble(this.taxCollectorId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.taxCollectorId = reader.ReadDouble();
      if (this.taxCollectorId < 0.0 || this.taxCollectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorId + ") on element of GuildFightJoinRequestMessage.taxCollectorId.");
    }
  }
}
