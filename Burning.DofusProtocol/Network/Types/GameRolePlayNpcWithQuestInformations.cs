using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
  {
    public new const uint Id = 383;
    public GameRolePlayNpcQuestFlag questFlag;

    public override uint TypeId
    {
      get
      {
        return 383;
      }
    }

    public GameRolePlayNpcWithQuestInformations()
    {
    }

    public GameRolePlayNpcWithQuestInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      uint npcId,
      bool sex,
      uint specialArtworkId,
      GameRolePlayNpcQuestFlag questFlag)
      : base(contextualId, disposition, look, npcId, sex, specialArtworkId)
    {
      this.questFlag = questFlag;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.questFlag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.questFlag = new GameRolePlayNpcQuestFlag();
      this.questFlag.Deserialize(reader);
    }
  }
}
