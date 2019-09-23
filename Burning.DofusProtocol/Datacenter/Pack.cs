using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Pack", true)]
  public class Pack : IDataObject
  {
    public const string MODULE = "Pack";
    public int Id;
    public string Name;
    public bool HasSubAreas;
  }
}
