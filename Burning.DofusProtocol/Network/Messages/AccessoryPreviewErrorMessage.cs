using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccessoryPreviewErrorMessage : NetworkMessage
  {
    public const uint Id = 6521;
    public uint error;

    public override uint MessageId
    {
      get
      {
        return 6521;
      }
    }

    public AccessoryPreviewErrorMessage()
    {
    }

    public AccessoryPreviewErrorMessage(uint error)
    {
      this.error = error;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.error);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.error = (uint) reader.ReadByte();
      if (this.error < 0U)
        throw new Exception("Forbidden value (" + (object) this.error + ") on element of AccessoryPreviewErrorMessage.error.");
    }
  }
}
