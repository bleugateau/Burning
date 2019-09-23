using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameContextActorInformations : GameContextActorPositionInformations
  {
    public new const uint Id = 150;
    public EntityLook look;

    public override uint TypeId
    {
      get
      {
        return 150;
      }
    }

    public GameContextActorInformations()
    {
    }

    public GameContextActorInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look)
      : base(contextualId, disposition)
    {
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
