using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("OptionalFeatures", true)]
  public class OptionalFeature : IDataObject
  {
    public const string MODULE = "OptionalFeatures";
    public int Id;
    public string Keyword;
  }
}
