using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
  {
    public new const uint Id = 214;
    public int stateId;

    public override uint TypeId
    {
      get
      {
        return 214;
      }
    }

    public FightTemporaryBoostStateEffect()
    {
    }

    public FightTemporaryBoostStateEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int delta,
      int stateId)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid, delta)
    {
      this.stateId = stateId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.stateId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.stateId = (int) reader.ReadShort();
    }
  }
}
