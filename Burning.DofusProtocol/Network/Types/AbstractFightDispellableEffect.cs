using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AbstractFightDispellableEffect
  {
    public const uint Id = 206;
    public uint uid;
    public double targetId;
    public int turnDuration;
    public uint dispelable;
    public uint spellId;
    public uint effectId;
    public uint ActionType;
    public double SourceId;
    public uint parentBoostUid;
    public int startTurn;

    public virtual uint TypeId
    {
      get
      {
        return 206;
      }
    }

    public AbstractFightDispellableEffect()
    {
    }

    public AbstractFightDispellableEffect(
      uint uid,
      double targetId,
      int turnDuration,
      uint dispelable,
      uint spellId,
      uint effectId,
      uint parentBoostUid)
    {
      this.uid = uid;
      this.targetId = targetId;
      this.turnDuration = turnDuration;
      this.dispelable = dispelable;
      this.spellId = spellId;
      this.effectId = effectId;
      this.parentBoostUid = parentBoostUid;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteVarInt((int) this.uid);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      writer.WriteShort((short) this.turnDuration);
      writer.WriteByte((byte) this.dispelable);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      if (this.effectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.effectId + ") on element effectId.");
      writer.WriteVarInt((int) this.effectId);
      if (this.parentBoostUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.parentBoostUid + ") on element parentBoostUid.");
      writer.WriteVarInt((int) this.parentBoostUid);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.uid = reader.ReadVarUhInt();
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of AbstractFightDispellableEffect.uid.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of AbstractFightDispellableEffect.targetId.");
      this.turnDuration = (int) reader.ReadShort();
      this.dispelable = (uint) reader.ReadByte();
      if (this.dispelable < 0U)
        throw new Exception("Forbidden value (" + (object) this.dispelable + ") on element of AbstractFightDispellableEffect.dispelable.");
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of AbstractFightDispellableEffect.spellId.");
      this.effectId = reader.ReadVarUhInt();
      if (this.effectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.effectId + ") on element of AbstractFightDispellableEffect.effectId.");
      this.parentBoostUid = reader.ReadVarUhInt();
      if (this.parentBoostUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.parentBoostUid + ") on element of AbstractFightDispellableEffect.parentBoostUid.");
    }
  }
}
