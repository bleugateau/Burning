using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentRankJntGift", true)]
  public class AlignmentRankJntGift : IDataObject
  {
    public const string MODULE = "AlignmentRankJntGift";
    public int Id;
    public List<int> Gifts;
    public List<int> Parameters;
    public List<int> Levels;
  }
}
