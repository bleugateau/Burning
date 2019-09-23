using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CharacteristicCategories", true)]
  public class CharacteristicCategory : IDataObject
  {
    public const string MODULE = "CharacteristicCategories";
    public int Id;
    public uint NameId;
    public int Order;
    public List<uint> CharacteristicIds;
  }
}
