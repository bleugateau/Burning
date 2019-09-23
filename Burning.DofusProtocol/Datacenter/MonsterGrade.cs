using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MonsterGrade", true)]
  public class MonsterGrade : IDataObject
  {
    public uint Grade;
    public int MonsterId;
    public uint Level;
    public int Vitality;
    public int PaDodge;
    public int PmDodge;
    public int Wisdom;
    public int EarthResistance;
    public int AirResistance;
    public int FireResistance;
    public int WaterResistance;
    public int NeutralResistance;
    public int GradeXp;
    public int LifePoints;
    public int ActionPoints;
    public int MovementPoints;
    public int DamageReflect;
    public uint HiddenLevel;
    public int Strength;
    public int Intelligence;
    public int Chance;
    public int Agility;
    public int StartingSpellId;
  }
}
