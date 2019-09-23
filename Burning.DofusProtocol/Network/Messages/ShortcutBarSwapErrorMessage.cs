using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarSwapErrorMessage : NetworkMessage
  {
    public const uint Id = 6226;
    public uint error;

    public override uint MessageId
    {
      get
      {
        return 6226;
      }
    }

    public ShortcutBarSwapErrorMessage()
    {
    }

    public ShortcutBarSwapErrorMessage(uint error)
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
        throw new Exception("Forbidden value (" + (object) this.error + ") on element of ShortcutBarSwapErrorMessage.error.");
    }
  }
}
