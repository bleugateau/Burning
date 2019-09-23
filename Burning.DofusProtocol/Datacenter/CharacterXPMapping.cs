using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CharacterXPMappings", true)]
  public class CharacterXPMapping : IDataObject
  {
    public const string MODULE = "CharacterXPMappings";
    public int Level;
    public double ExperiencePoints;
  }
}
