using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Incarnation", true)]
  public class Incarnation : IDataObject
  {
    public const string MODULE = "Incarnation";
    public uint Id;
    public string LookMale;
    public string LookFemale;
  }
}
