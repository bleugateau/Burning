using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestSteps", true)]
  public class QuestStep : IDataObject
  {
    public const string MODULE = "QuestSteps";
    public uint Id;
    public uint QuestId;
    public uint NameId;
    public uint DescriptionId;
    public int DialogId;
    public uint OptimalLevel;
    public double Duration;
    public List<uint> ObjectiveIds;
    public List<uint> RewardsIds;
  }
}
