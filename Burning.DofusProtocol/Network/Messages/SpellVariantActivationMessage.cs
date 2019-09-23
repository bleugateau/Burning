using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SpellVariantActivationMessage : NetworkMessage
  {
    public const uint Id = 6705;
    public uint spellId;
    public bool result;

    public override uint MessageId
    {
      get
      {
        return 6705;
      }
    }

    public SpellVariantActivationMessage()
    {
    }

    public SpellVariantActivationMessage(uint spellId, bool result)
    {
      this.spellId = spellId;
      this.result = result;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      writer.WriteBoolean(this.result);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of SpellVariantActivationMessage.spellId.");
      this.result = reader.ReadBoolean();
    }
  }
}
