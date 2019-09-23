using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntLegendaryRequestMessage : NetworkMessage
  {
    public const uint Id = 6499;
    public uint legendaryId;

    public override uint MessageId
    {
      get
      {
        return 6499;
      }
    }

    public TreasureHuntLegendaryRequestMessage()
    {
    }

    public TreasureHuntLegendaryRequestMessage(uint legendaryId)
    {
      this.legendaryId = legendaryId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.legendaryId < 0U)
        throw new Exception("Forbidden value (" + (object) this.legendaryId + ") on element legendaryId.");
      writer.WriteVarShort((short) this.legendaryId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.legendaryId = (uint) reader.ReadVarUhShort();
      if (this.legendaryId < 0U)
        throw new Exception("Forbidden value (" + (object) this.legendaryId + ") on element of TreasureHuntLegendaryRequestMessage.legendaryId.");
    }
  }
}
