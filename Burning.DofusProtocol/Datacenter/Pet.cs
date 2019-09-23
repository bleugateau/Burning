using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Pets", true)]
  public class Pet : IDataObject
  {
    public const string MODULE = "Pets";
    public int Id;
    public List<int> FoodItems;
    public List<int> FoodTypes;
    public int MinDurationBeforeMeal;
    public int MaxDurationBeforeMeal;
    public List<EffectInstance> PossibleEffects;
  }
}
