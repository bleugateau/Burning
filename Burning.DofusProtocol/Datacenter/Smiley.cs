using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Smileys", true)]
  public class Smiley : IDataObject
  {
    public const string MODULE = "Smileys";
    public uint Id;
    public uint Order;
    public string GfxId;
    public bool ForPlayers;
    public List<string> Triggers;
    public uint ReferenceId;
    public uint CategoryId;
  }
}
