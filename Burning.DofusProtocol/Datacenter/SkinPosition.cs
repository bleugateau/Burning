using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Data.D2o.other;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SkinPositions", true)]
  public class SkinPosition : IDataObject
  {
    private const string MODULE = "SkinPositions";
    public uint Id;
    public List<TransformData> Transformation;
    public List<string> Clip;
    public List<uint> Skin;
  }
}
