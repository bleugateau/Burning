using FlatyBot.Common.IO;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Burning.DofusProtocol.Data.D2P
{
  public class D2pManager
  {
    private static D2pFileManager _d2PFileManager;

    public static void Setup(string directory)
    {
      D2pManager._d2PFileManager = new D2pFileManager(directory);
    }

    public static Map FromId(double id)
    {
      string name = (id % 10.0).ToString() + "/" + (object) (int) id + ".dlm";
      byte[] mapBytes = D2pManager._d2PFileManager.GetMapBytes(name);
      if (mapBytes == null)
        return (Map) null;
      MemoryStream memoryStream1 = new MemoryStream(D2pManager._d2PFileManager.GetMapBytes(name));
      memoryStream1.Position = 2L;
      DeflateStream deflateStream = new DeflateStream((Stream) memoryStream1, CompressionMode.Decompress);
      byte[] buffer = new byte[8192];
      MemoryStream memoryStream2 = new MemoryStream();
      int count;
      while ((count = deflateStream.Read(buffer, 0, buffer.Length)) > 0)
        memoryStream2.Write(buffer, 0, count);
      memoryStream2.Position = 0L;
      BigEndianReader bigEndianReader = new BigEndianReader((Stream) memoryStream2);
      Map map = new Map();
      map.FromRaw(bigEndianReader, Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4"));
      Array.Clear((Array) mapBytes, 0, mapBytes.Length);
      return map;
    }
  }
}
