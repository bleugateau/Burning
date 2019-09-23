using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
  {
    public new const uint Id = 211;
    public int weaponTypeId;

    public override uint TypeId
    {
      get
      {
        return 211;
      }
    }

    public FightTemporaryBoostWeaponDamagesEffect()
    {
    }

    public FightTemporaryBoostWeaponDamagesEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int delta,
      int weaponTypeId)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid, delta)
    {
      this.weaponTypeId = weaponTypeId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.weaponTypeId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.weaponTypeId = (int) reader.ReadShort();
    }
  }
}
