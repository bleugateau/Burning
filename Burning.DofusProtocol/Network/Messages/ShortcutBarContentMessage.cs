using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ShortcutBarContentMessage : NetworkMessage
  {
    public List<Shortcut> shortcuts = new List<Shortcut>();
    public const uint Id = 6231;
    public uint barType;

    public override uint MessageId
    {
      get
      {
        return 6231;
      }
    }

    public ShortcutBarContentMessage()
    {
    }

    public ShortcutBarContentMessage(uint barType, List<Shortcut> shortcuts)
    {
      this.barType = barType;
      this.shortcuts = shortcuts;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.barType);
      writer.WriteShort((short) this.shortcuts.Count);
      for (int index = 0; index < this.shortcuts.Count; ++index)
      {
        writer.WriteShort((short) this.shortcuts[index].TypeId);
        this.shortcuts[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.barType = (uint) reader.ReadByte();
      if (this.barType < 0U)
        throw new Exception("Forbidden value (" + (object) this.barType + ") on element of ShortcutBarContentMessage.barType.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        Shortcut instance = ProtocolTypeManager.GetInstance<Shortcut>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.shortcuts.Add(instance);
      }
    }
  }
}
