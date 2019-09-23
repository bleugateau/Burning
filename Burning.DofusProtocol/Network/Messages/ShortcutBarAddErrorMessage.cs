using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarAddErrorMessage : NetworkMessage
  {
    public const uint Id = 6227;
    public uint error;

    public override uint MessageId
    {
      get
      {
        return 6227;
      }
    }

    public ShortcutBarAddErrorMessage()
    {
    }

    public ShortcutBarAddErrorMessage(uint error)
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
        throw new Exception("Forbidden value (" + (object) this.error + ") on element of ShortcutBarAddErrorMessage.error.");
    }
  }
}
