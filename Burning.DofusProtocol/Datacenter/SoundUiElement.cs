using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SoundUiElement", true)]
  public class SoundUiElement : IDataObject
  {
    public string MODULE = nameof (SoundUiElement);
    public uint Id;
    public string Name;
    public uint HookId;
    public string File;
    public uint Volume;
  }
}
