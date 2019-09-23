using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ItemTypes", true)]
  public class ItemType : IDataObject
  {
    public const string MODULE = "ItemTypes";
    public int Id;
    public uint NameId;
    public uint SuperTypeId;
    public bool Plural;
    public uint Gender;
    public string RawZone;
    public bool Mimickable;
    public int CraftXpRatio;
    public int CategoryId;
    public int EvolutiveTypeId;
    public bool IsInEncyclopedia;
  }
}
