using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("Signs", true)]
  public class Sign : IDataObject
  {
    public const string MODULE = "Signs";
    public int Id;
    public string Params;
    public int SkillId;
    public uint TextKey;
  }
}
