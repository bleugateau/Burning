using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Tips", true)]
  public class Tips : IDataObject
  {
    public const string MODULE = "Tips";
    public int Id;
    public uint DescId;
  }
}
