using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
  {
    public new const uint Id = 36;
    public ActorAlignmentInformations alignmentInfos;

    public override uint TypeId
    {
      get
      {
        return 36;
      }
    }

    public GameRolePlayCharacterInformations()
    {
    }

    public GameRolePlayCharacterInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name,
      HumanInformations humanoidInfo,
      uint accountId,
      ActorAlignmentInformations alignmentInfos)
      : base(contextualId, disposition, look, name, humanoidInfo, accountId)
    {
      this.alignmentInfos = alignmentInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.alignmentInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.alignmentInfos = new ActorAlignmentInformations();
      this.alignmentInfos.Deserialize(reader);
    }
  }
}
