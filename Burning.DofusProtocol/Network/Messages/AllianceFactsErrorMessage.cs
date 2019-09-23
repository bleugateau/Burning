using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceFactsErrorMessage : NetworkMessage
  {
    public const uint Id = 6423;
    public uint allianceId;

    public override uint MessageId
    {
      get
      {
        return 6423;
      }
    }

    public AllianceFactsErrorMessage()
    {
    }

    public AllianceFactsErrorMessage(uint allianceId)
    {
      this.allianceId = allianceId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of AllianceFactsErrorMessage.allianceId.");
    }
  }
}
