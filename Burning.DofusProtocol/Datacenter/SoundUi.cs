using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SoundUi", true)]
  public class SoundUi : IDataObject
  {
    public string MODULE = nameof (SoundUi);
    public uint Id;
    public string UiName;
    public string OpenFile;
    public string CloseFile;
    public List<SoundUiElement> SubElements;
  }
}
