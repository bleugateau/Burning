using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntFinishedMessage : NetworkMessage
  {
    public const uint Id = 6483;
    public uint questType;

    public override uint MessageId
    {
      get
      {
        return 6483;
      }
    }

    public TreasureHuntFinishedMessage()
    {
    }

    public TreasureHuntFinishedMessage(uint questType)
    {
      this.questType = questType;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntFinishedMessage.questType.");
    }
  }
}
