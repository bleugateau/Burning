using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountSetXpRatioRequestMessage : NetworkMessage
  {
    public const uint Id = 5989;
    public uint xpRatio;

    public override uint MessageId
    {
      get
      {
        return 5989;
      }
    }

    public MountSetXpRatioRequestMessage()
    {
    }

    public MountSetXpRatioRequestMessage(uint xpRatio)
    {
      this.xpRatio = xpRatio;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.xpRatio < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpRatio + ") on element xpRatio.");
      writer.WriteByte((byte) this.xpRatio);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.xpRatio = (uint) reader.ReadByte();
      if (this.xpRatio < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpRatio + ") on element of MountSetXpRatioRequestMessage.xpRatio.");
    }
  }
}
