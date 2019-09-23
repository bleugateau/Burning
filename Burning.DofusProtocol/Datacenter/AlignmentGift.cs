using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentGift", true)]
  public class AlignmentGift : IDataObject
  {
    public const string MODULE = "AlignmentGift";
    public int Id;
    public uint NameId;
    public int EffectId;
    public uint GfxId;
  }
}
