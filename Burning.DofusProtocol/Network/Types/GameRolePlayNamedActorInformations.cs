using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 154;
    public string name;

    public override uint TypeId
    {
      get
      {
        return 154;
      }
    }

    public GameRolePlayNamedActorInformations()
    {
    }

    public GameRolePlayNamedActorInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name)
      : base(contextualId, disposition, look)
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
