using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Titles", true)]
  public class Title : IDataObject
  {
    public const string MODULE = "Titles";
    public int Id;
    public uint NameMaleId;
    public uint NameFemaleId;
    public bool Visible;
    public int CategoryId;
  }
}
