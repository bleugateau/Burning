using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountXpRatioMessage : NetworkMessage
  {
    public const uint Id = 5970;
    public uint ratio;

    public override uint MessageId
    {
      get
      {
        return 5970;
      }
    }

    public MountXpRatioMessage()
    {
    }

    public MountXpRatioMessage(uint ratio)
    {
      this.ratio = ratio;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.ratio < 0U)
        throw new Exception("Forbidden value (" + (object) this.ratio + ") on element ratio.");
      writer.WriteByte((byte) this.ratio);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.ratio = (uint) reader.ReadByte();
      if (this.ratio < 0U)
        throw new Exception("Forbidden value (" + (object) this.ratio + ") on element of MountXpRatioMessage.ratio.");
    }
  }
}
