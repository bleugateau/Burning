using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("ArenaLeagueSeasons", true)]
  public class ArenaLeagueSeason : IDataObject
  {
    public const string MODULE = "ArenaLeagueSeasons";
    public uint NameId;
    public int Id;
  }
}
