using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
  {
    public new const uint Id = 445;
    public BasicGuildInformations guild;

    public override uint TypeId
    {
      get
      {
        return 445;
      }
    }

    public CharacterMinimalGuildInformations()
    {
    }

    public CharacterMinimalGuildInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      BasicGuildInformations guild)
      : base(id, name, level, entityLook, breed)
    {
      this.guild = guild;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guild = new BasicGuildInformations();
      this.guild.Deserialize(reader);
    }
  }
}
