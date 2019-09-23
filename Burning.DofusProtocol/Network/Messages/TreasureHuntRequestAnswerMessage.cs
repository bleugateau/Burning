using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntRequestAnswerMessage : NetworkMessage
  {
    public const uint Id = 6489;
    public uint questType;
    public uint result;

    public override uint MessageId
    {
      get
      {
        return 6489;
      }
    }

    public TreasureHuntRequestAnswerMessage()
    {
    }

    public TreasureHuntRequestAnswerMessage(uint questType, uint result)
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
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntRequestAnswerMessage.questType.");
      this.result = (uint) reader.ReadByte();
      if (this.result < 0U)
        throw new Exception("Forbidden value (" + (object) this.result + ") on element of TreasureHuntRequestAnswerMessage.result.");
    }
  }
}
