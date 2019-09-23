using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Burning.DofusProtocol.Data.D2P
{
  public sealed class D2pFileManager
  {
    private readonly List<D2PFileDlm> _listD2PFileDlm = new List<D2PFileDlm>();

    public D2pFileManager(string path)
    {
      foreach (string file in Directory.GetFiles(path))
      {
        if (new FileInfo(file).Extension.ToUpper() == ".D2P")
          this._listD2PFileDlm.Add(new D2PFileDlm(file));
      }
    }

    public byte[] GetMapBytes(string name)
    {
      return this._listD2PFileDlm.FirstOrDefault<D2PFileDlm>((Func<D2PFileDlm, bool>) (f => f.ExistsDlm(name)))?.ReadFile(name);
    }
  }
}
