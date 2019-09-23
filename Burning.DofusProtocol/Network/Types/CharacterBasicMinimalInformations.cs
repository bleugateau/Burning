using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterBasicMinimalInformations : AbstractCharacterInformation
  {
    public new const uint Id = 503;
    public string name;

    public override uint TypeId
    {
      get
      {
        return 503;
      }
    }

    public CharacterBasicMinimalInformations()
    {
    }

    public CharacterBasicMinimalInformations(double id, string name)
      : base(id)
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
