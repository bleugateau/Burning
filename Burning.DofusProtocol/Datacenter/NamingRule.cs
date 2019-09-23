using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("NamingRules", true)]
  public class NamingRule : IDataObject
  {
    public const string MODULE = "NamingRules";
    public uint Id;
    public uint MinLength;
    public uint MaxLength;
    public string Regexp;
  }
}
