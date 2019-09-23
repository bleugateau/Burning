using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
  {
    public new const uint Id = 444;
    public BasicAllianceInformations alliance;

    public override uint TypeId
    {
      get
      {
        return 444;
      }
    }

    public CharacterMinimalAllianceInformations()
    {
    }

    public CharacterMinimalAllianceInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      BasicGuildInformations guild,
      BasicAllianceInformations alliance)
      : base(id, name, level, entityLook, breed, guild)
    {
      this.alliance = alliance;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.alliance.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.alliance = new BasicAllianceInformations();
      this.alliance.Deserialize(reader);
    }
  }
}
