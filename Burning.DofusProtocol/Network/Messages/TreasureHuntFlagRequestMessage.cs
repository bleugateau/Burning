using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TreasureHuntFlagRequestMessage : NetworkMessage
  {
    public const uint Id = 6508;
    public uint questType;
    public uint index;

    public override uint MessageId
    {
      get
      {
        return 6508;
      }
    }

    public TreasureHuntFlagRequestMessage()
    {
    }

    public TreasureHuntFlagRequestMessage(uint questType, uint index)
    {
      this.questType = questType;
      this.index = index;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.questType);
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element index.");
      writer.WriteByte((byte) this.index);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.questType = (uint) reader.ReadByte();
      if (this.questType < 0U)
        throw new Exception("Forbidden value (" + (object) this.questType + ") on element of TreasureHuntFlagRequestMessage.questType.");
      this.index = (uint) reader.ReadByte();
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element of TreasureHuntFlagRequestMessage.index.");
    }
  }
}
