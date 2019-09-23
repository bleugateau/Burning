using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFightLeaveRequestMessage : NetworkMessage
  {
    public const uint Id = 5715;
    public double taxCollectorId;
    public double characterId;

    public override uint MessageId
    {
      get
      {
        return 5715;
      }
    }

    public GuildFightLeaveRequestMessage()
    {
    }

    public GuildFightLeaveRequestMessage(double taxCollectorId, double characterId)
    {
      this.taxCollectorId = taxCollectorId;
      this.characterId = characterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.taxCollectorId < 0.0 || this.taxCollectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorId + ") on element taxCollectorId.");
      writer.WriteDouble(this.taxCollectorId);
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.taxCollectorId = reader.ReadDouble();
      if (this.taxCollectorId < 0.0 || this.taxCollectorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.taxCollectorId + ") on element of GuildFightLeaveRequestMessage.taxCollectorId.");
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of GuildFightLeaveRequestMessage.characterId.");
    }
  }
}
