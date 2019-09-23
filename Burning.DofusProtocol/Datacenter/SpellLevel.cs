using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpellLevels", true)]
  public class SpellLevel : IDataObject
  {
    public const string MODULE = "SpellLevels";
    public uint Id;
    public uint SpellId;
    public uint Grade;
    public uint SpellBreed;
    public uint ApCost;
    public uint MinRange;
    public uint Range;
    public bool CastInLine;
    public bool CastInDiagonal;
    public bool CastTestLos;
    public uint CriticalHitProbability;
    public bool NeedFreeCell;
    public bool NeedTakenCell;
    public bool NeedFreeTrapCell;
    public bool RangeCanBeBoosted;
    public int MaxStack;
    public uint MaxCastPerTurn;
    public uint MaxCastPerTarget;
    public uint MinCastInterval;
    public uint InitialCooldown;
    public int GlobalCooldown;
    public uint MinPlayerLevel;
    public bool HideEffects;
    public bool Hidden;
    public bool PlayAnimation;
    public List<int> StatesRequired;
    public List<int> StatesAuthorized;
    public List<int> StatesForbidden;
    public List<EffectInstanceDice> Effects;
    public List<EffectInstanceDice> CriticalEffect;
    public List<string> AdditionalEffectsZones;
  }
}
