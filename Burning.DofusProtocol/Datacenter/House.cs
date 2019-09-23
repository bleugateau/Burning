using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Houses", true)]
  public class House : IDataObject
  {
    public const string MODULE = "Houses";
    public int TypeId;
    public uint DefaultPrice;
    public int NameId;
    public int DescriptionId;
    public int GfxId;
  }
}
