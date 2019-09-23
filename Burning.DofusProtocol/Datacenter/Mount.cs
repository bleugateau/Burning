using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Mounts", true)]
  public class Mount : IDataObject
  {
    private string MODULE = "Mounts";
    public uint Id;
    public uint FamilyId;
    public uint NameId;
    public string Look;
    public int CertificateId;
    public List<EffectInstance> Effects;
  }
}
