using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightNoSpellCastMessage : NetworkMessage
  {
    public const uint Id = 6132;
    public uint spellLevelId;

    public override uint MessageId
    {
      get
      {
        return 6132;
      }
    }

    public GameActionFightNoSpellCastMessage()
    {
    }

    public GameActionFightNoSpellCastMessage(uint spellLevelId)
    {
      this.spellLevelId = spellLevelId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellLevelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellLevelId + ") on element spellLevelId.");
      writer.WriteVarInt((int) this.spellLevelId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellLevelId = reader.ReadVarUhInt();
      if (this.spellLevelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellLevelId + ") on element of GameActionFightNoSpellCastMessage.spellLevelId.");
    }
  }
}
