using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightAIInformations : GameFightFighterInformations
  {
    public new const uint Id = 151;

    public override uint TypeId
    {
      get
      {
        return 151;
      }
    }

    public GameFightAIInformations()
    {
    }

    public GameFightAIInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
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
