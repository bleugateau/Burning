using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("LuaFormulas", true)]
  public class LuaFormulas : IDataObject
  {
    public const string MODULE = "LuaFormulas";
    public int Id;
    public string LuaFormula;
    public string FormulaName;
  }
}
