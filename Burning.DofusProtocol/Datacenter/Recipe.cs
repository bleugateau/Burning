using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Recipes", true)]
  public class Recipe : IDataObject
  {
    public const string MODULE = "Recipes";
    public int ResultId;
    public uint ResultNameId;
    public uint ResultTypeId;
    public uint ResultLevel;
    public List<int> IngredientIds;
    public List<uint> Quantities;
    public int JobId;
    public int SkillId;
  }
}
