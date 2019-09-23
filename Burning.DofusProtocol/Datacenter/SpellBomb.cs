using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellBombs", true)]
  public class SpellBomb : IDataObject
  {
    public const string MODULE = "SpellBombs";
    public int Id;
    public int ChainReactionSpellId;
    public int ExplodSpellId;
    public int WallId;
    public int InstantSpellId;
    public int ComboCoeff;
  }
}
