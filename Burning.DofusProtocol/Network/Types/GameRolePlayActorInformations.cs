using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayActorInformations : GameContextActorInformations
  {
    public new const uint Id = 141;

    public override uint TypeId
    {
      get
      {
        return 141;
      }
    }

    public GameRolePlayActorInformations()
    {
    }

    public GameRolePlayActorInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look)
      : base(contextualId, disposition, look)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
