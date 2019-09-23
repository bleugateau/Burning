using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
  {
    public List<int> portalsIds = new List<int>();
    public new const uint Id = 1010;
    public uint spellId;
    public int spellLevel;

    public override uint MessageId
    {
      get
      {
        return 1010;
      }
    }

    public GameActionFightSpellCastMessage()
    {
    }

    public GameActionFightSpellCastMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int destinationCellId,
      uint critical,
      bool silentCast,
      bool verboseCast,
      uint spellId,
      int spellLevel,
      List<int> portalsIds)
      : base(actionId, sourceId, targetId, destinationCellId, critical, silentCast, verboseCast)
    {
      this.spellId = spellId;
      this.spellLevel = spellLevel;
      this.portalsIds = portalsIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      if (this.spellLevel < 1 || this.spellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.spellLevel + ") on element spellLevel.");
      writer.WriteShort((short) this.spellLevel);
      writer.WriteShort((short) this.portalsIds.Count);
      for (int index = 0; index < this.portalsIds.Count; ++index)
        writer.WriteShort((short) this.portalsIds[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameActionFightSpellCastMessage.spellId.");
      this.spellLevel = (int) reader.ReadShort();
      if (this.spellLevel < 1 || this.spellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.spellLevel + ") on element of GameActionFightSpellCastMessage.spellLevel.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.portalsIds.Add((int) reader.ReadShort());
    }
  }
}
