using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayPortalInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 467;
    public PortalInformation portal;

    public override uint TypeId
    {
      get
      {
        return 467;
      }
    }

    public GameRolePlayPortalInformations()
    {
    }

    public GameRolePlayPortalInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      PortalInformation portal)
      : base(contextualId, disposition, look)
    {
      this.portal = portal;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.portal.TypeId);
      this.portal.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.portal = ProtocolTypeManager.GetInstance<PortalInformation>((uint) reader.ReadUShort());
      this.portal.Deserialize(reader);
    }
  }
}
