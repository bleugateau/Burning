using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
  {
    public const uint Id = 6491;
    public uint questType;
    public int availableRetryCount;

    public override uint MessageId
    {
      get
      {
        return 6491;
      }
    }

    public TreasureHuntAvailableRetryCountUpdateMessage()
    {
    }

    public TreasureHuntAvailableRetryCountUpdateMessage(uint questType, int availableRetryCount)
    {
      this.questType = questType;
      this.availableRetryCount = availableRetryCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
      writer.WriteInt(this.availableRetryCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntAvailableRetryCountUpdateMessage.questType.");
      this.availableRetryCount = reader.ReadInt();
    }
  }
}
