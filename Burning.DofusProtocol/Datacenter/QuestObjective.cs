using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Data.D2o.other;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestObjectives", true)]
  public class QuestObjective : IDataObject
  {
    public const string MODULE = "QuestObjectives";
    public uint Id;
    public uint StepId;
    public uint TypeId;
    public int DialogId;
    public QuestObjectiveParameters Parameters;
    public Point Coords;
    public double MapId;
    public QuestObjectiveType Type;
  }
}
