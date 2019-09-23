using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("SpellConversions", true)]
  public class SpellConversion : IDataObject
  {
    public const string MODULE = "SpellConversions";
    public int OldSpellId;
    public int NewSpellId;
  }
}
