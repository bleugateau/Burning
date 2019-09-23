using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SkinMappings", true)]
  public class SkinMapping : IDataObject
  {
    public const string MODULE = "SkinMappings";
    public int Id;
    public int LowDefId;
  }
}
