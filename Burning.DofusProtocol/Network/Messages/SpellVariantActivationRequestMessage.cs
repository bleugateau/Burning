using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SpellVariantActivationRequestMessage : NetworkMessage
  {
    public const uint Id = 6707;
    public uint spellId;

    public override uint MessageId
    {
      get
      {
        return 6707;
      }
    }

    public SpellVariantActivationRequestMessage()
    {
    }

    public SpellVariantActivationRequestMessage(uint spellId)
    {
      this.spellId = spellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of SpellVariantActivationRequestMessage.spellId.");
    }
  }
}
