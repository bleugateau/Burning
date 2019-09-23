using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Burning.DofusProtocol.Data.D2P
{
  public class D2PFileDlm
  {
    private readonly object _checkLock;
    private readonly FileStream _d2PFileStream;
    private readonly Dictionary<string, int[]> _filenameDataDictionnary;
    private readonly BigEndianReader _reader;

    public D2PFileDlm(string d2PFilePath)
    {
      this._d2PFileStream = new FileStream(d2PFilePath, FileMode.Open, FileAccess.Read);
      this._reader = new BigEndianReader((Stream) this._d2PFileStream);
      this._filenameDataDictionnary = new Dictionary<string, int[]>();
      this._checkLock = RuntimeHelpers.GetObjectValue(new object());
      if (Convert.ToByte((int) this._reader.ReadByte() + (int) this._reader.ReadByte()) != (byte) 3)
        return;
      this._d2PFileStream.Position = this._d2PFileStream.Length - 24L;
      int int32_1 = Convert.ToInt32(this._reader.ReadInt());
      this._reader.ReadInt();
      int int32_2 = Convert.ToInt32(this._reader.ReadInt());
      int int32_3 = Convert.ToInt32(this._reader.ReadInt());
      Convert.ToInt32(this._reader.ReadInt());
      Convert.ToInt32(this._reader.ReadInt());
      this._d2PFileStream.Position = (long) int32_2;
      int num = int32_3;
      for (int index = 1; index <= num; ++index)
        this._filenameDataDictionnary.Add(this._reader.ReadUTF(), new int[2]
        {
          this._reader.ReadInt() + int32_1,
          this._reader.ReadInt()
        });
    }

    public bool ExistsDlm(string dlmName)
    {
      return this._filenameDataDictionnary.ContainsKey(dlmName);
    }

    public byte[] ReadFile(string fileName)
    {
      lock (this._checkLock)
      {
        int[] numArray = this._filenameDataDictionnary[fileName];
        this._d2PFileStream.Position = (long) numArray[0];
        return this._reader.ReadBytes(numArray[1]);
      }
    }
  }
}
