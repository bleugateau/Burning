using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestObjectiveTypes", true)]
  public class QuestObjectiveType : IDataObject
  {
    public const string MODULE = "QuestObjectiveTypes";
    public uint Id;
    public uint NameId;
  }
}
