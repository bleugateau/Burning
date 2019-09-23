using FlatyBot.Common.Extensions;
using Burning.DofusProtocol.Data.D2P;
using System.Collections.Generic;
using System.IO;

namespace Burning.DofusProtocol.Data.Icons
{
  public class IconsManager : Singleton<IconsManager>
  {
    private List<D2PFileDlm> files;

    public void Initialize(string path)
    {
      this.files = new List<D2PFileDlm>();
      foreach (string file in Directory.GetFiles(path))
      {
        if (file.Contains("bitmap"))
          this.files.Add(new D2PFileDlm(file));
      }
    }

    public Icon GetIcon(int id)
    {
      foreach (D2PFileDlm file in this.files)
      {
        if (file.ExistsDlm(id.ToString() + ".png"))
          return new Icon(id, id.ToString() + ".png", file.ReadFile(id.ToString() + ".png"));
      }
      return (Icon) null;
    }
  }
}
