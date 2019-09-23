using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutSpell : Shortcut
  {
    public new const uint Id = 368;
    public uint spellId;

    public override uint TypeId
    {
      get
      {
        return 368;
      }
    }

    public ShortcutSpell()
    {
    }

    public ShortcutSpell(uint slot, uint spellId)
      : base(slot)
    {
      this.spellId = spellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of ShortcutSpell.spellId.");
    }
  }
}
