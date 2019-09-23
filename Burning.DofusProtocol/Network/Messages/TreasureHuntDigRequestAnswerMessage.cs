using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntDigRequestAnswerMessage : NetworkMessage
  {
    public const uint Id = 6484;
    public uint questType;
    public uint result;

    public override uint MessageId
    {
      get
      {
        return 6484;
      }
    }

    public TreasureHuntDigRequestAnswerMessage()
    {
    }

    public TreasureHuntDigRequestAnswerMessage(uint questType, uint result)
    {
      this.questType = questType;
      this.result = result;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
      writer.WriteByte((byte) this.result);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntDigRequestAnswerMessage.questType.");
      this.result = (uint) reader.ReadByte();
      if (this.result < 0U)
        throw new Exception("Forbidden value (" + (object) this.result + ") on element of TreasureHuntDigRequestAnswerMessage.result.");
    }
  }
}
