using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarReplacedMessage : NetworkMessage
  {
    public const uint Id = 6706;
    public uint barType;
    public Shortcut shortcut;

    public override uint MessageId
    {
      get
      {
        return 6706;
      }
    }

    public ShortcutBarReplacedMessage()
    {
    }

    public ShortcutBarReplacedMessage(uint barType, Shortcut shortcut)
    {
      this.barType = barType;
      this.shortcut = shortcut;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.barType);
      writer.WriteShort((short) this.shortcut.TypeId);
      this.shortcut.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.barType = (uint) reader.ReadByte();
      if (this.barType < 0U)
        throw new Exception("Forbidden value (" + (object) this.barType + ") on element of ShortcutBarReplacedMessage.barType.");
      this.shortcut = ProtocolTypeManager.GetInstance<Shortcut>((uint) reader.ReadUShort());
      this.shortcut.Deserialize(reader);
    }
  }
}
