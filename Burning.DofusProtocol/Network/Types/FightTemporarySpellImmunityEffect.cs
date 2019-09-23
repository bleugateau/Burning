using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
  {
    public new const uint Id = 366;
    public int immuneSpellId;

    public override uint TypeId
    {
      get
      {
        return 366;
      }
    }

    public FightTemporarySpellImmunityEffect()
    {
    }

    public FightTemporarySpellImmunityEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int immuneSpellId)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid)
    {
      this.immuneSpellId = immuneSpellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.immuneSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.immuneSpellId = reader.ReadInt();
    }
  }
}
