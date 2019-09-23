using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SmileyPacks", true)]
  public class SmileyPack : IDataObject
  {
    public const string MODULE = "SmileyPacks";
    public uint Id;
    public uint NameId;
    public uint Order;
    public List<uint> Smileys;
  }
}
