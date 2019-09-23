using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MonsterDrop", true)]
  public class MonsterDrop : IDataObject
  {
    public uint DropId;
    public int MonsterId;
    public int ObjectId;
    public double PercentDropForGrade1;
    public double PercentDropForGrade2;
    public double PercentDropForGrade3;
    public double PercentDropForGrade4;
    public double PercentDropForGrade5;
    public int Count;
    public bool HasCriteria;
    public string Criteria;
    public List<int> SpecificDropCoefficient;
  }
}
