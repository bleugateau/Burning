using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismUseRequestMessage : NetworkMessage
  {
    public const uint Id = 6041;
    public uint moduleToUse;

    public override uint MessageId
    {
      get
      {
        return 6041;
      }
    }

    public PrismUseRequestMessage()
    {
    }

    public PrismUseRequestMessage(uint moduleToUse)
    {
      this.moduleToUse = moduleToUse;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.moduleToUse);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.moduleToUse = (uint) reader.ReadByte();
      if (this.moduleToUse < 0U)
        throw new Exception("Forbidden value (" + (object) this.moduleToUse + ") on element of PrismUseRequestMessage.moduleToUse.");
    }
  }
}
