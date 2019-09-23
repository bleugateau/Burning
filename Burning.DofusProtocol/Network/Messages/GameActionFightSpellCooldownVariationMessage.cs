using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6219;
    public double targetId;
    public uint spellId;
    public int value;

    public override uint MessageId
    {
      get
      {
        return 6219;
      }
    }

    public GameActionFightSpellCooldownVariationMessage()
    {
    }

    public GameActionFightSpellCooldownVariationMessage(
      uint actionId,
      double sourceId,
      double targetId,
      uint spellId,
      int value)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.spellId = spellId;
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      writer.WriteVarShort((short) this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightSpellCooldownVariationMessage.targetId.");
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameActionFightSpellCooldownVariationMessage.spellId.");
      this.value = (int) reader.ReadVarShort();
    }
  }
}
