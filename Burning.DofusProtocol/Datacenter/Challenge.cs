using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Challenge", true)]
  public class Challenge : IDataObject
  {
    public const string MODULE = "Challenge";
    public int Id;
    public uint NameId;
    public uint DescriptionId;
    public bool DareAvailable;
    public List<uint> IncompatibleChallenges;
  }
}
