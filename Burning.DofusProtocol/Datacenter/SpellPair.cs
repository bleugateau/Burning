using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellPairs", true)]
  public class SpellPair : IDataObject
  {
    public const string MODULE = "SpellPairs";
    public int Id;
    public uint NameId;
    public uint DescriptionId;
    public int IconId;
  }
}
