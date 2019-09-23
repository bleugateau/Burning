using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlaySpellAnimMessage : NetworkMessage
  {
    public const uint Id = 6114;
    public double casterId;
    public uint targetCellId;
    public uint spellId;
    public int spellLevel;

    public override uint MessageId
    {
      get
      {
        return 6114;
      }
    }

    public GameRolePlaySpellAnimMessage()
    {
    }

    public GameRolePlaySpellAnimMessage(
      double casterId,
      uint targetCellId,
      uint spellId,
      int spellLevel)
    {
      this.casterId = casterId;
      this.targetCellId = targetCellId;
      this.spellId = spellId;
      this.spellLevel = spellLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.casterId < 0.0 || this.casterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.casterId + ") on element casterId.");
      writer.WriteVarLong((long) this.casterId);
      if (this.targetCellId < 0U || this.targetCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element targetCellId.");
      writer.WriteVarShort((short) this.targetCellId);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      if (this.spellLevel < 1 || this.spellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.spellLevel + ") on element spellLevel.");
      writer.WriteShort((short) this.spellLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.casterId = (double) reader.ReadVarUhLong();
      if (this.casterId < 0.0 || this.casterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.casterId + ") on element of GameRolePlaySpellAnimMessage.casterId.");
      this.targetCellId = (uint) reader.ReadVarUhShort();
      if (this.targetCellId < 0U || this.targetCellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.targetCellId + ") on element of GameRolePlaySpellAnimMessage.targetCellId.");
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameRolePlaySpellAnimMessage.spellId.");
      this.spellLevel = (int) reader.ReadShort();
      if (this.spellLevel < 1 || this.spellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.spellLevel + ") on element of GameRolePlaySpellAnimMessage.spellLevel.");
    }
  }
}
