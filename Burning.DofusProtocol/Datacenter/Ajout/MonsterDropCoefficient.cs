using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("MonsterDropCoefficient", true)]
  public class MonsterDropCoefficient : IDataObject
  {
    public const string MODULE = "MonsterDropCoefficient";
    public uint MonsterId;
    public uint MonsterGrade;
    public double DropCoefficient;
    public string Criteria;
  }
}
