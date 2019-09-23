using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Burning.DofusProtocol.Data.D2i
{
  public class FastD2IReader : IDisposable
  {
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static readonly FastD2I _myD2I = new FastD2I();
    private static volatile FastD2IReader _instance;
    private static bool _isFastLoad;
    private static string _pather;
    private static BinaryReader _br;
    private readonly Stream _stream;
    private bool _disposedValue;

    public static FastD2IReader Instance
    {
      get
      {
        FastD2IReader._semaphore.Wait();
        if (FastD2IReader._instance == null)
          FastD2IReader._instance = new FastD2IReader();
        FastD2IReader._semaphore.Release();
        return FastD2IReader._instance;
      }
    }

    public void Init(string d2IPath, bool fastLoad = true)
    {
      FastD2IReader._isFastLoad = fastLoad;
      FastD2IReader._pather = d2IPath;
      if (FastD2IReader._isFastLoad)
        return;
      FastD2IReader.LoadD2I();
    }

    private static void LoadD2I()
    {
      using (FastD2IReader._br = new BinaryReader((Stream) File.Open(FastD2IReader._pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
      {
        FastD2IReader._myD2I.SizeOfD2I = FastD2IReader._br.BaseStream.Length;
        FastD2IReader._myD2I.SizeOfData = FastD2IReader.ReadInt();
        while (FastD2IReader._br.BaseStream.Position < (long) FastD2IReader._myD2I.SizeOfData)
        {
          DataD2I dataD2I = new DataD2I() { StrIndex = FastD2IReader._br.BaseStream.Position, StrSize = FastD2IReader.ReadShort() };
          dataD2I.Str = FastD2IReader.ReadUtf8(dataD2I.StrSize);
          FastD2IReader._myD2I.DataList.Add(dataD2I);
        }
        FastD2IReader._myD2I.SizeOfIndex = FastD2IReader.ReadInt();
        while (FastD2IReader._br.BaseStream.Position - (long) FastD2IReader._myD2I.SizeOfData < (long) FastD2IReader._myD2I.SizeOfIndex)
        {
          Index index = new Index() { IStrKey = FastD2IReader.ReadInt(), IDiaExist = FastD2IReader.ReadBool(), IStrIndex = FastD2IReader.ReadInt() };
          if (index.IDiaExist)
            index.IDiaIndex = FastD2IReader.ReadInt();
          FastD2IReader._myD2I.IndexList.Add(index);
        }
        FastD2IReader._br.Dispose();
        GC.Collect();
      }
    }

    public string GetText<T>(T toSearch, bool versionDiacritique = false)
    {
      FastD2IReader._semaphore.Wait();
      DataD2I dataD2I = new DataD2I() { Str = "" };
      uint myId;
      if (typeof (T) == typeof (string))
        myId = Convert.ToUInt32((object) toSearch);
      else
        uint.TryParse(toSearch.ToString(), out myId);
      if (!FastD2IReader._isFastLoad)
      {
        try
        {
          if (versionDiacritique)
          {
            uint pointer;
            try
            {
              pointer = FastD2IReader._myD2I.IndexList.First<Index>((Func<Index, bool>) (n => (int) n.IStrKey == (int) myId & n.IDiaExist)).IDiaIndex;
            }
            catch (Exception ex)
            {
              pointer = FastD2IReader._myD2I.IndexList.First<Index>((Func<Index, bool>) (n => (int) n.IStrKey == (int) myId)).IStrIndex;
            }
            dataD2I.Str = FastD2IReader._myD2I.DataList.First<DataD2I>((Func<DataD2I, bool>) (m => m.StrIndex == (long) pointer)).Str;
          }
          else
          {
            uint pointer = FastD2IReader._myD2I.IndexList.First<Index>((Func<Index, bool>) (n => (int) n.IStrKey == (int) myId)).IStrIndex;
            dataD2I.Str = FastD2IReader._myD2I.DataList.First<DataD2I>((Func<DataD2I, bool>) (m => m.StrIndex == (long) pointer)).Str;
          }
        }
        catch (Exception ex)
        {
        }
      }
      else
      {
        using (FastD2IReader._br = new BinaryReader((Stream) File.Open(FastD2IReader._pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
        {
          FastD2IReader._myD2I.SizeOfD2I = FastD2IReader._br.BaseStream.Length;
          FastD2IReader._myD2I.SizeOfData = FastD2IReader.ReadInt();
          FastD2IReader._br.BaseStream.Position = (long) FastD2IReader._myD2I.SizeOfData;
          FastD2IReader._myD2I.SizeOfIndex = FastD2IReader.ReadInt();
          try
          {
            while (FastD2IReader._br.BaseStream.Position - (long) FastD2IReader._myD2I.SizeOfData < (long) FastD2IReader._myD2I.SizeOfIndex)
            {
              Index index = new Index();
              uint num1 = FastD2IReader.ReadInt();
              if ((int) num1 == (int) myId)
              {
                index.IStrKey = num1;
                index.IDiaExist = FastD2IReader.ReadBool();
                index.IStrIndex = FastD2IReader.ReadInt();
                if (index.IDiaExist)
                  index.IDiaIndex = FastD2IReader.ReadInt();
                uint num2 = versionDiacritique ? index.IDiaIndex : index.IStrIndex;
                FastD2IReader._br.BaseStream.Position = (long) num2;
                dataD2I.StrIndex = (long) num2;
                dataD2I.StrSize = FastD2IReader.ReadShort();
                dataD2I.Str = FastD2IReader.ReadUtf8(dataD2I.StrSize);
                break;
              }
              index.IDiaExist = FastD2IReader.ReadBool();
              index.IStrIndex = FastD2IReader.ReadInt();
              if (index.IDiaExist)
                index.IDiaIndex = FastD2IReader.ReadInt();
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      FastD2IReader._semaphore.Release();
      return dataD2I.Str;
    }

    public string GetUi(string mySearch)
    {
      FastD2IReader._semaphore.Wait();
      string str = "No Result";
      using (FastD2IReader._br = new BinaryReader((Stream) File.Open(FastD2IReader._pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
      {
        FastD2IReader._br.BaseStream.Position = 0L;
        FastD2IReader._myD2I.SizeOfD2I = FastD2IReader._br.BaseStream.Length;
        FastD2IReader._myD2I.SizeOfData = FastD2IReader.ReadInt();
        FastD2IReader._br.BaseStream.Position = (long) FastD2IReader._myD2I.SizeOfData;
        FastD2IReader._myD2I.SizeOfIndex = FastD2IReader.ReadInt();
        FastD2IReader._br.BaseStream.Position += (long) FastD2IReader._myD2I.SizeOfIndex;
        FastD2IReader._myD2I.SizeOfUi = FastD2IReader.ReadInt();
        try
        {
          while (FastD2IReader._br.BaseStream.Position < FastD2IReader._br.BaseStream.Length)
          {
            UI ui = new UI() { UStrIndex = FastD2IReader.ReadShort() };
            ui.UStr = FastD2IReader.ReadUtf8(ui.UStrIndex);
            ui.UPointer = FastD2IReader.ReadInt();
            if (string.Compare(mySearch, ui.UStr, StringComparison.OrdinalIgnoreCase) == 0)
            {
              FastD2IReader._br.BaseStream.Position = (long) ui.UPointer;
              DataD2I dataD2I = new DataD2I() { StrIndex = (long) ui.UPointer, StrSize = FastD2IReader.ReadShort() };
              dataD2I.Str = FastD2IReader.ReadUtf8(dataD2I.StrSize);
              str = dataD2I.Str;
              break;
            }
          }
        }
        catch (Exception ex)
        {
        }
      }
      FastD2IReader._semaphore.Release();
      return str;
    }

    private static uint ReadInt()
    {
      return BitConverter.ToUInt32(((IEnumerable<byte>) FastD2IReader._br.ReadBytes(4)).Reverse<byte>().ToArray<byte>(), 0);
    }

    private static ushort ReadShort()
    {
      return BitConverter.ToUInt16(((IEnumerable<byte>) FastD2IReader._br.ReadBytes(2)).Reverse<byte>().ToArray<byte>(), 0);
    }

    private static bool ReadBool()
    {
      return FastD2IReader._br.ReadBoolean();
    }

    private static string ReadUtf8(ushort mySize)
    {
      return Encoding.UTF8.GetString(FastD2IReader._br.ReadBytes((int) mySize));
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposedValue)
      {
        int num = disposing ? 1 : 0;
        try
        {
          FastD2IReader._br.Dispose();
        }
        catch (Exception ex)
        {
        }
        try
        {
          this._stream.Dispose();
        }
        catch (Exception ex)
        {
        }
      }
      this._disposedValue = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }
  }
}
