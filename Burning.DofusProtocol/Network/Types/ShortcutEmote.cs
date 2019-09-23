using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutEmote : Shortcut
  {
    public new const uint Id = 389;
    public uint emoteId;

    public override uint TypeId
    {
      get
      {
        return 389;
      }
    }

    public ShortcutEmote()
    {
    }

    public ShortcutEmote(uint slot, uint emoteId)
      : base(slot)
    {
      this.emoteId = emoteId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element emoteId.");
      writer.WriteByte((byte) this.emoteId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.emoteId = (uint) reader.ReadByte();
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element of ShortcutEmote.emoteId.");
    }
  }
}
