using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ArenaLeagueReward", true)]
  public class ArenaLeagueReward : IDataObject
  {
    public const string MODULE = "ArenaLeagueReward";
    public int Id;
    public uint SeasonId;
    public uint LeagueId;
    public List<uint> TitlesRewards;
    public bool EndSeasonRewards;
  }
}
