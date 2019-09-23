using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SkillNames", true)]
  public class SkillName : IDataObject
  {
    public const string MODULE = "SkillNames";
    public int Id;
    public uint NameId;
  }
}
