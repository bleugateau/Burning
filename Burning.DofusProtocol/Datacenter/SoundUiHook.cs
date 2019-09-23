using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SoundUiHook", true)]
  public class SoundUiHook : IDataObject
  {
    public string MODULE = nameof (SoundUiHook);
    public uint Id;
    public string Name;
  }
}
