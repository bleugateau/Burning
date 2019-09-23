using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
  {
    public new const uint Id = 456;
    public string name;

    public override uint TypeId
    {
      get
      {
        return 456;
      }
    }

    public GameFightFighterNamedLightInformations()
    {
    }

    public GameFightFighterNamedLightInformations(
      double id,
      uint wave,
      uint level,
      int breed,
      bool sex,
      bool alive,
      string name)
      : base(id, wave, level, breed, sex, alive)
    {
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
    }
  }
}
