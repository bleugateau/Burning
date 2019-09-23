using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Emoticons", true)]
  public class Emoticon : IDataObject
  {
    public uint Cooldown = 1000;
    public const string MODULE = "Emoticons";
    public uint Id;
    public uint NameId;
    public uint ShortcutId;
    public uint Order;
    public string DefaultAnim;
    public bool Persistancy;
    public bool EightDirections;
    public bool Aura;
    public List<string> Anims;
    public uint Duration;
    public uint Weight;
    public uint SpellLevelId;
    public bool Eightdirections;
  }
}
