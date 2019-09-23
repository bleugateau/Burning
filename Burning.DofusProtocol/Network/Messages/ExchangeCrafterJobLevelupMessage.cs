using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCrafterJobLevelupMessage : NetworkMessage
  {
    public const uint Id = 6598;
    public uint crafterJobLevel;

    public override uint MessageId
    {
      get
      {
        return 6598;
      }
    }

    public ExchangeCrafterJobLevelupMessage()
    {
    }

    public ExchangeCrafterJobLevelupMessage(uint crafterJobLevel)
    {
      this.crafterJobLevel = crafterJobLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.crafterJobLevel < 0U || this.crafterJobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.crafterJobLevel + ") on element crafterJobLevel.");
      writer.WriteByte((byte) this.crafterJobLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.crafterJobLevel = (uint) reader.ReadByte();
      if (this.crafterJobLevel < 0U || this.crafterJobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.crafterJobLevel + ") on element of ExchangeCrafterJobLevelupMessage.crafterJobLevel.");
    }
  }
}
