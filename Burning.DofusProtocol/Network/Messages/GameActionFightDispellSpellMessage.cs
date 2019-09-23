using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
  {
    public new const uint Id = 6176;
    public uint spellId;

    public override uint MessageId
    {
      get
      {
        return 6176;
      }
    }

    public GameActionFightDispellSpellMessage()
    {
    }

    public GameActionFightDispellSpellMessage(
      uint actionId,
      double sourceId,
      double targetId,
      bool verboseCast,
      uint spellId)
      : base(actionId, sourceId, targetId, verboseCast)
    {
      this.spellId = spellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameActionFightDispellSpellMessage.spellId.");
    }
  }
}
