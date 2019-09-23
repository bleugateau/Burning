using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTriggeredEffect : AbstractFightDispellableEffect
  {
    public new const uint Id = 210;
    public int param1;
    public int param2;
    public int param3;
    public int delay;

    public override uint TypeId
    {
      get
      {
        return 210;
      }
    }

    public FightTriggeredEffect()
    {
    }

    public FightTriggeredEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid,
      int param1,
      int param2,
      int param3,
      int delay)
      : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid)
    {
      this.param1 = param1;
      this.param2 = param2;
      this.param3 = param3;
      this.delay = delay;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.param1);
      writer.WriteInt(this.param2);
      writer.WriteInt(this.param3);
      writer.WriteShort((short) this.delay);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.param1 = reader.ReadInt();
      this.param2 = reader.ReadInt();
      this.param3 = reader.ReadInt();
      this.delay = (int) reader.ReadShort();
    }
  }
}
