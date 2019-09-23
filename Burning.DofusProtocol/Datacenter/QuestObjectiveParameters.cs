using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestObjectiveParameters", true)]
  public class QuestObjectiveParameters : IDataObject
  {
    public uint NumParams;
    public int Parameter0;
    public int Parameter1;
    public int Parameter2;
    public int Parameter3;
    public int Parameter4;
    public bool DungeonOnly;
  }
}
