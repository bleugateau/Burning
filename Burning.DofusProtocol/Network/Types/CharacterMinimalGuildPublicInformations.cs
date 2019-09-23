using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalGuildPublicInformations : CharacterMinimalInformations
  {
    public new const uint Id = 556;
    public uint rank;

    public override uint TypeId
    {
      get
      {
        return 556;
      }
    }

    public CharacterMinimalGuildPublicInformations()
    {
    }

    public CharacterMinimalGuildPublicInformations(double id, string name, uint level, uint rank)
      : base(id, name, level)
    {
      this.rank = rank;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarInt((int) this.rank);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.rank = reader.ReadVarUhInt();
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of CharacterMinimalGuildPublicInformations.rank.");
    }
  }
}
