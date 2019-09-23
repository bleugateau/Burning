using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Spells", true)]
  public class Spell : IDataObject
  {
    public bool UseParamCache = true;
    public const string MODULE = "Spells";
    public int Id;
    public uint NameId;
    public uint DescriptionId;
    public uint TypeId;
    public uint Order;
    public string ScriptParams;
    public string ScriptParamsCritical;
    public int ScriptId;
    public int ScriptIdCritical;
    public int IconId;
    public List<uint> SpellLevels;
    public bool Verbosecast;
    public bool UseSpellLevelScaling;
    public string Defaultzone;
    public bool BypassSummoningLimit;
    public bool CanAlwaysTriggerSpells;
  }
}
