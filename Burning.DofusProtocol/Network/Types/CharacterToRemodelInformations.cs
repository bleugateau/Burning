using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterToRemodelInformations : CharacterRemodelingInformation
  {
    public new const uint Id = 477;
    public uint possibleChangeMask;
    public uint mandatoryChangeMask;

    public override uint TypeId
    {
      get
      {
        return 477;
      }
    }

    public CharacterToRemodelInformations()
    {
    }

    public CharacterToRemodelInformations(
      double id,
      string name,
      int breed,
      bool sex,
      uint cosmeticId,
      List<int> colors,
      uint possibleChangeMask,
      uint mandatoryChangeMask)
      : base(id, name, breed, sex, cosmeticId, colors)
    {
      this.possibleChangeMask = possibleChangeMask;
      this.mandatoryChangeMask = mandatoryChangeMask;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.possibleChangeMask < 0U)
        throw new Exception("Forbidden value (" + (object) this.possibleChangeMask + ") on element possibleChangeMask.");
      writer.WriteByte((byte) this.possibleChangeMask);
      if (this.mandatoryChangeMask < 0U)
        throw new Exception("Forbidden value (" + (object) this.mandatoryChangeMask + ") on element mandatoryChangeMask.");
      writer.WriteByte((byte) this.mandatoryChangeMask);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.possibleChangeMask = (uint) reader.ReadByte();
      if (this.possibleChangeMask < 0U)
        throw new Exception("Forbidden value (" + (object) this.possibleChangeMask + ") on element of CharacterToRemodelInformations.possibleChangeMask.");
      this.mandatoryChangeMask = (uint) reader.ReadByte();
      if (this.mandatoryChangeMask < 0U)
        throw new Exception("Forbidden value (" + (object) this.mandatoryChangeMask + ") on element of CharacterToRemodelInformations.mandatoryChangeMask.");
    }
  }
}
