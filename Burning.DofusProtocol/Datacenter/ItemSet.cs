using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ItemSets", true)]
  public class ItemSet : IDataObject
  {
    public const string MODULE = "ItemSets";
    public uint Id;
    public List<uint> Items;
    public uint NameId;
    public List<List<EffectInstance>> Effects;
    public bool BonusIsSecret;
  }
}
