using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
  {
    public new const uint Id = 6509;
    public uint wrongFlagCount;

    public override uint MessageId
    {
      get
      {
        return 6509;
      }
    }

    public TreasureHuntDigRequestAnswerFailedMessage()
    {
    }

    public TreasureHuntDigRequestAnswerFailedMessage(
      uint questType,
      uint result,
      uint wrongFlagCount)
      : base(questType, result)
    {
      this.wrongFlagCount = wrongFlagCount;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.wrongFlagCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.wrongFlagCount + ") on element wrongFlagCount.");
      writer.WriteByte((byte) this.wrongFlagCount);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.wrongFlagCount = (uint) reader.ReadByte();
      if (this.wrongFlagCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.wrongFlagCount + ") on element of TreasureHuntDigRequestAnswerFailedMessage.wrongFlagCount.");
    }
  }
}
