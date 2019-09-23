using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("ServerTemporisSeasons", true)]
  public class ServerTemporisSeason : IDataObject
  {
    public const string MODULE = "ServerTemporisSeasons";
    public int Uid;
    public uint Seasondouble;
    public string Information;
    public double Beginning;
    public double Closure;
    public int SeasonNumber;
  }
}
