using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentTitles", true)]
  public class AlignmentTitle : IDataObject
  {
    public const string MODULE = "AlignmentTitles";
    public int SideId;
    public List<int> NamesId;
    public List<int> ShortsId;
  }
}
