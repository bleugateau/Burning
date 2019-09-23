using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildSpellUpgradeRequestMessage : NetworkMessage
  {
    public const uint Id = 5699;
    public uint spellId;

    public override uint MessageId
    {
      get
      {
        return 5699;
      }
    }

    public GuildSpellUpgradeRequestMessage()
    {
    }

    public GuildSpellUpgradeRequestMessage(uint spellId)
    {
      this.spellId = spellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteInt((int) this.spellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadInt();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GuildSpellUpgradeRequestMessage.spellId.");
    }
  }
}
