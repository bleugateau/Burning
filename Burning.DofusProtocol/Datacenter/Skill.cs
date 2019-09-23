using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Skills", true)]
  public class Skill : IDataObject
  {
    public const string MODULE = "Skills";
    public int Id;
    public uint NameId;
    public int ParentJobId;
    public bool IsForgemagus;
    public List<int> ModifiableItemTypeIds;
    public int GatheredRessourceItem;
    public List<int> CraftableItemIds;
    public int InteractiveId;
    public string UseAnimation;
    public int Cursor;
    public int ElementActionId;
    public bool AvailableInHouse;
    public uint LevelMin;
    public bool ClientDisplay;
    public int Range;
    public bool UseRangeInClient;
  }
}
