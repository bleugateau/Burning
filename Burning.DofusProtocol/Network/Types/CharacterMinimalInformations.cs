using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalInformations : CharacterBasicMinimalInformations
  {
    public new const uint Id = 110;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 110;
      }
    }

    public CharacterMinimalInformations()
    {
    }

    public CharacterMinimalInformations(double id, string name, uint level)
      : base(id, name)
    {
      this.level = level;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of CharacterMinimalInformations.level.");
    }
  }
}
