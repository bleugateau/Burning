using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarRemoveRequestMessage : NetworkMessage
  {
    public const uint Id = 6228;
    public uint barType;
    public uint slot;

    public override uint MessageId
    {
      get
      {
        return 6228;
      }
    }

    public ShortcutBarRemoveRequestMessage()
    {
    }

    public ShortcutBarRemoveRequestMessage(uint barType, uint slot)
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
        throw new Exception("Forbidden value (" + (object) this.barType + ") on element of ShortcutBarRemoveRequestMessage.barType.");
      this.slot = (uint) reader.ReadByte();
      if (this.slot < 0U || this.slot > 99U)
        throw new Exception("Forbidden value (" + (object) this.slot + ") on element of ShortcutBarRemoveRequestMessage.slot.");
    }
  }
}
