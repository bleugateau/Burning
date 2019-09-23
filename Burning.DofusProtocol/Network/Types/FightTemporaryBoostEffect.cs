using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
  {
    public new const uint Id = 209;
    public int delta;

    public override uint TypeId
    {
      get
      {
        return 209;
      }
    }

    public FightTemporaryBoostEffect()
    {
    }

    public FightTemporaryBoostEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int delta)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid)
    {
      this.delta = delta;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.delta);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.delta = (int) reader.ReadShort();
    }
  }
}
