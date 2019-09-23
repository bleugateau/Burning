using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
  {
    public new const uint Id = 474;
    public uint deathState;
    public uint deathCount;
    public uint deathMaxLevel;

    public override uint TypeId
    {
      get
      {
        return 474;
      }
    }

    public CharacterHardcoreOrEpicInformations()
    {
    }

    public CharacterHardcoreOrEpicInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      bool sex,
      uint deathState,
      uint deathCount,
      uint deathMaxLevel)
      : base(id, name, level, entityLook, breed, sex)
    {
      this.deathState = deathState;
      this.deathCount = deathCount;
      this.deathMaxLevel = deathMaxLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.deathState);
      if (this.deathCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.deathCount + ") on element deathCount.");
      writer.WriteVarShort((short) this.deathCount);
      if (this.deathMaxLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.deathMaxLevel + ") on element deathMaxLevel.");
      writer.WriteVarShort((short) this.deathMaxLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.deathState = (uint) reader.ReadByte();
      if (this.deathState < 0U)
        throw new Exception("Forbidden value (" + (object) this.deathState + ") on element of CharacterHardcoreOrEpicInformations.deathState.");
      this.deathCount = (uint) reader.ReadVarUhShort();
      if (this.deathCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.deathCount + ") on element of CharacterHardcoreOrEpicInformations.deathCount.");
      this.deathMaxLevel = (uint) reader.ReadVarUhShort();
      if (this.deathMaxLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.deathMaxLevel + ") on element of CharacterHardcoreOrEpicInformations.deathMaxLevel.");
    }
  }
}
