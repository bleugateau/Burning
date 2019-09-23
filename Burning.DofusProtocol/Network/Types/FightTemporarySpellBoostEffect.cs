using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
  {
    public new const uint Id = 207;
    public uint boostedSpellId;

    public override uint TypeId
    {
      get
      {
        return 207;
      }
    }

    public FightTemporarySpellBoostEffect()
    {
    }

    public FightTemporarySpellBoostEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int delta,
      uint boostedSpellId)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid, delta)
    {
      this.boostedSpellId = boostedSpellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.boostedSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostedSpellId + ") on element boostedSpellId.");
      writer.WriteVarShort((short) this.boostedSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.boostedSpellId = (uint) reader.ReadVarUhShort();
      if (this.boostedSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostedSpellId + ") on element of FightTemporarySpellBoostEffect.boostedSpellId.");
    }
  }
}
