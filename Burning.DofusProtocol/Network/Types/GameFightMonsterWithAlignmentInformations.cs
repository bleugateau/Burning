using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
  {
    public new const uint Id = 203;
    public ActorAlignmentInformations alignmentInfos;

    public override uint TypeId
    {
      get
      {
        return 203;
      }
    }

    public GameFightMonsterWithAlignmentInformations()
    {
    }

    public GameFightMonsterWithAlignmentInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions,
      uint creatureGenericId,
      uint creatureGrade,
      uint creatureLevel,
      ActorAlignmentInformations alignmentInfos)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, creatureGenericId, creatureGrade, creatureLevel)
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
