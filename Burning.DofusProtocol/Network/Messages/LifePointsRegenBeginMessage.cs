using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LifePointsRegenBeginMessage : NetworkMessage
  {
    public const uint Id = 5684;
    public uint regenRate;

    public override uint MessageId
    {
      get
      {
        return 5684;
      }
    }

    public LifePointsRegenBeginMessage()
    {
    }

    public LifePointsRegenBeginMessage(uint regenRate)
    {
      this.regenRate = regenRate;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element regenRate.");
      writer.WriteByte((byte) this.regenRate);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.regenRate = (uint) reader.ReadByte();
      if (this.regenRate < 0U || this.regenRate > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.regenRate + ") on element of LifePointsRegenBeginMessage.regenRate.");
    }
  }
}
