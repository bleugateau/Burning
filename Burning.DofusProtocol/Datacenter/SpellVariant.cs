using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellVariants", true)]
  public class SpellVariant : IDataObject
  {
    public const string MODULE = "SpellVariants";
    public int Id;
    public uint BreedId;
    public List<uint> SpellIds;
  }
}
