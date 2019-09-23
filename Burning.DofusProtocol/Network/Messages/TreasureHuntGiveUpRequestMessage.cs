using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntGiveUpRequestMessage : NetworkMessage
  {
    public const uint Id = 6487;
    public uint questType;

    public override uint MessageId
    {
      get
      {
        return 6487;
      }
    }

    public TreasureHuntGiveUpRequestMessage()
    {
    }

    public TreasureHuntGiveUpRequestMessage(uint questType)
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
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntGiveUpRequestMessage.questType.");
    }
  }
}
