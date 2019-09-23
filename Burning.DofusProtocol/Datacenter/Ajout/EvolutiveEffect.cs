using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("EvolutiveEffects", true)]
  public class EvolutiveEffect : IDataObject
  {
    public const string MODULE = "EvolutiveEffects";
    public int Id;
    public int ActionId;
    public int TargetId;
    private List<List<double>> ProgressionPerLevelRange;
  }
}
