using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayPrismInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 161;
    public PrismInformation prism;

    public override uint TypeId
    {
      get
      {
        return 161;
      }
    }

    public GameRolePlayPrismInformations()
    {
    }

    public GameRolePlayPrismInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      PrismInformation prism)
      : base(contextualId, disposition, look)
    {
      this.prism = prism;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.prism.TypeId);
      this.prism.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.prism = ProtocolTypeManager.GetInstance<PrismInformation>((uint) reader.ReadUShort());
      this.prism.Deserialize(reader);
    }
  }
}
