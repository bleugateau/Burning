using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("TypeActions", true)]
  public class TypeAction : IDataObject
  {
    public const string MODULE = "TypeActions";
    public int Id;
    public string ElementName;
    public int ElementId;
  }
}
