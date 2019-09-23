using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
  {
    public new const uint Id = 5741;
    public int markId;
    public uint markImpactCell;
    public double triggeringCharacterId;
    public uint triggeredSpellId;

    public override uint MessageId
    {
      get
      {
        return 5741;
      }
    }

    public GameActionFightTriggerGlyphTrapMessage()
    {
    }

    public GameActionFightTriggerGlyphTrapMessage(
      uint actionId,
      double sourceId,
      int markId,
      uint markImpactCell,
      double triggeringCharacterId,
      uint triggeredSpellId)
      : base(actionId, sourceId)
    {
      this.markId = markId;
      this.markImpactCell = markImpactCell;
      this.triggeringCharacterId = triggeringCharacterId;
      this.triggeredSpellId = triggeredSpellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.markId);
      if (this.markImpactCell < 0U)
        throw new Exception("Forbidden value (" + (object) this.markImpactCell + ") on element markImpactCell.");
      writer.WriteVarShort((short) this.markImpactCell);
      if (this.triggeringCharacterId < -9.00719925474099E+15 || this.triggeringCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.triggeringCharacterId + ") on element triggeringCharacterId.");
      writer.WriteDouble(this.triggeringCharacterId);
      if (this.triggeredSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.triggeredSpellId + ") on element triggeredSpellId.");
      writer.WriteVarShort((short) this.triggeredSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.markId = (int) reader.ReadShort();
      this.markImpactCell = (uint) reader.ReadVarUhShort();
      if (this.markImpactCell < 0U)
        throw new Exception("Forbidden value (" + (object) this.markImpactCell + ") on element of GameActionFightTriggerGlyphTrapMessage.markImpactCell.");
      this.triggeringCharacterId = reader.ReadDouble();
      if (this.triggeringCharacterId < -9.00719925474099E+15 || this.triggeringCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.triggeringCharacterId + ") on element of GameActionFightTriggerGlyphTrapMessage.triggeringCharacterId.");
      this.triggeredSpellId = (uint) reader.ReadVarUhShort();
      if (this.triggeredSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.triggeredSpellId + ") on element of GameActionFightTriggerGlyphTrapMessage.triggeredSpellId.");
    }
  }
}
