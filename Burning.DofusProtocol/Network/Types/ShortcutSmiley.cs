using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ShortcutSmiley : Shortcut
  {
    public new const uint Id = 388;
    public uint smileyId;

    public override uint TypeId
    {
      get
      {
        return 388;
      }
    }

    public ShortcutSmiley()
    {
    }

    public ShortcutSmiley(uint slot, uint smileyId)
      : base(slot)
    {
      this.smileyId = smileyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element smileyId.");
      writer.WriteVarShort((short) this.smileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.smileyId = (uint) reader.ReadVarUhShort();
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element of ShortcutSmiley.smileyId.");
    }
  }
}
