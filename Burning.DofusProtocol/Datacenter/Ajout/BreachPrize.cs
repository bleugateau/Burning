using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("BreachPrizes", true)]
  public class BreachPrize : IDataObject
  {
    public const string MODULE = "BreachPrizes";
    public int Id;
    public uint NameId;
    public int Currency;
    public string TooltipKey;
    public int CategoryId;
    public int ItemId;
    public uint DescriptionKey;
  }
}
