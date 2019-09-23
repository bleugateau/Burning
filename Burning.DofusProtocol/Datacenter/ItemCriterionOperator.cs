using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ItemCriterionOperator", true)]
  public class ItemCriterionOperator : IDataObject
  {
    public const string SUPERIOR = ">";
    public const string INFERIOR = "<";
    public const string EQUAL = "";
    public const string DIFFERENT = "!";
  }
}
