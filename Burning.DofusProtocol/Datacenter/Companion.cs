using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Companions", true)]
  public class Companion : IDataObject
  {
    public const string MODULE = "Companions";
    public int Id;
    public uint NameId;
    public string Look;
    public bool WebDisplay;
    public uint DescriptionId;
    public uint StartingSpellLevelId;
    public uint AssetId;
    public List<uint> Characteristics;
    public List<uint> Spells;
    public int CreatureBoneId;
  }
}
