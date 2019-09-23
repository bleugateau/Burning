using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CompanionSpells", true)]
  public class CompanionSpell : IDataObject
  {
    public const string MODULE = "CompanionSpells";
    public int Id;
    public int SpellId;
    public int CompanionId;
    public string GradeByLevel;
  }
}
