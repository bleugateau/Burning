using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellTypes", true)]
  public class SpellType : IDataObject
  {
    public const string MODULE = "SpellTypes";
    public int Id;
    public uint LongNameId;
    public uint ShortNameId;
  }
}
