using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Weapon", true)]
  public class Weapon : Item
  {
    public int ApCost;
    public int MinRange;
    public int Range;
    public uint MaxCastPerTurn;
    public bool CastInLine;
    public bool CastInDiagonal;
    public bool CastTestLos;
    public int CriticalHitProbability;
    public int CriticalHitBonus;
    public int CriticalFailureProbability;
  }
}
