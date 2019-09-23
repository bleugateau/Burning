using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntFlagRequestAnswerMessage : NetworkMessage
  {
    public const uint Id = 6507;
    public uint questType;
    public uint result;
    public uint index;

    public override uint MessageId
    {
      get
      {
        return 6507;
      }
    }

    public TreasureHuntFlagRequestAnswerMessage()
    {
    }

    public TreasureHuntFlagRequestAnswerMessage(uint questType, uint result, uint index)
    {
      this.questType = questType;
      this.result = result;
      this.index = index;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
      writer.WriteByte((byte) this.result);
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element index.");
      writer.WriteByte((byte) this.index);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntFlagRequestAnswerMessage.questType.");
      this.result = (uint) reader.ReadByte();
      if (this.result < 0U)
        throw new Exception("Forbidden value (" + (object) this.result + ") on element of TreasureHuntFlagRequestAnswerMessage.result.");
      this.index = (uint) reader.ReadByte();
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element of TreasureHuntFlagRequestAnswerMessage.index.");
    }
  }
}
