using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SoundBones", true)]
  public class SoundBones : IDataObject
  {
    public string MODULE = nameof (SoundBones);
    public uint Id;
    public List<string> Keys;
    public List<List<SoundAnimation>> Values;
  }
}
