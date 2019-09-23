using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("EvolutiveItemTypes", true)]
  public class EvolutiveItemType : IDataObject
  {
    public const string MODULE = "EvolutiveItemTypes";
    public int Id;
    public uint MaxLevel;
    public double ExperienceBoost;
    public List<int> ExperienceByLevel;
  }
}
