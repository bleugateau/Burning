using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarRemovedMessage : NetworkMessage
  {
    public const uint Id = 6224;
    public uint barType;
    public uint slot;

    public override uint MessageId
    {
      get
      {
        return 6224;
      }
    }

    public ShortcutBarRemovedMessage()
    {
    }

    public ShortcutBarRemovedMessage(uint barType, uint slot)
    {
      this.barType = barType;
      this.slot = slot;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.barType);
      if (this.slot < 0U || this.slot > 99U)
        throw new Exception("Forbidden value (" + (object) this.slot + ") on element slot.");
      writer.WriteByte((byte) this.slot);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.barType = (uint) reader.ReadByte();
      if (this.barType < 0U)
        throw new Exception("Forbidden value (" + (object) this.barType + ") on element of ShortcutBarRemovedMessage.barType.");
      this.slot = (uint) reader.ReadByte();
      if (this.slot < 0U || this.slot > 99U)
        throw new Exception("Forbidden value (" + (object) this.slot + ") on element of ShortcutBarRemovedMessage.slot.");
    }
  }
}
