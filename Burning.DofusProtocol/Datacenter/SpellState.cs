using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellStates", true)]
  public class SpellState : IDataObject
  {
    public string Icon = "";
    public const string MODULE = "SpellStates";
    public int Id;
    public uint NameId;
    public bool PreventsSpellCast;
    public bool PreventsFight;
    public bool IsSilent;
    public bool CantDealDamage;
    public bool Invulnerable;
    public bool Incurable;
    public bool CantBeMoved;
    public bool CantBePushed;
    public bool CantSwitchPosition;
    public List<int> EffectsIds;
    public int IconVisibilityMask;
    public bool InvulnerableMelee;
    public bool InvulnerableRange;
    public bool CantTackle;
    public bool CantBeTackled;
  }
}
