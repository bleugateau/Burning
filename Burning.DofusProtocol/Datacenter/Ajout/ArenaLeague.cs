using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("ArenaLeagues", true)]
  public class ArenaLeague : IDataObject
  {
    public const string MODULE = "ArenaLeagues";
    public int Id;
    public uint NameId;
    public uint OrnamentId;
    public string Icon;
    public string Illus;
    public bool IsLastLeague;
  }
}
