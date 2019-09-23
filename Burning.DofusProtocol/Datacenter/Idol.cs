using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Idols", true)]
  public class Idol : IDataObject
  {
    public const string MODULE = "Idols";
    public int Id;
    public string Description;
    public int CategoryId;
    public int ItemId;
    public bool GroupOnly;
    public int SpellPairId;
    public int Score;
    public int ExperienceBonus;
    public int DropBonus;
    public List<int> SynergyIdolsIds;
    public List<double> SynergyIdolsCoeff;
    public List<int> IncompatibleMonsters;
  }
}
