using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntDigRequestMessage : NetworkMessage
  {
    public const uint Id = 6485;
    public uint questType;

    public override uint MessageId
    {
      get
      {
        return 6485;
      }
    }

    public TreasureHuntDigRequestMessage()
    {
    }

    public TreasureHuntDigRequestMessage(uint questType)
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
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntDigRequestMessage.questType.");
    }
  }
}
