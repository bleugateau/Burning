using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterSpellModification
  {
    public const uint Id = 215;
    public uint modificationType;
    public uint spellId;
    public CharacterBaseCharacteristic value;

    public virtual uint TypeId
    {
      get
      {
        return 215;
      }
    }

    public CharacterSpellModification()
    {
    }

    public CharacterSpellModification(
      uint modificationType,
      uint spellId,
      CharacterBaseCharacteristic value)
    {
      this.modificationType = modificationType;
      this.spellId = spellId;
      this.value = value;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.modificationType);
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      this.value.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.modificationType = (uint) reader.ReadByte();
      if (this.modificationType < 0U)
        throw new Exception("Forbidden value (" + (object) this.modificationType + ") on element of CharacterSpellModification.modificationType.");
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of CharacterSpellModification.spellId.");
      this.value = new CharacterBaseCharacteristic();
      this.value.Deserialize(reader);
    }
  }
}
