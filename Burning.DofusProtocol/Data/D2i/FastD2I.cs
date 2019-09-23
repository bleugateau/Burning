using System.Collections.Generic;

namespace Burning.DofusProtocol.Data.D2i
{
  public class FastD2I
  {
    public long SizeOfD2I { get; set; }

    public uint SizeOfData { get; set; }

    public List<DataD2I> DataList { get; set; } = new List<DataD2I>();

    public uint SizeOfIndex { get; set; }

    public List<Index> IndexList { get; set; } = new List<Index>();

    public uint SizeOfUi { get; set; }
  }
}
