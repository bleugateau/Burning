using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Heads", true)]
  public class Head : IDataObject
  {
    public const string MODULE = "Heads";
    public int Id;
    public string Skins;
    public string AssetId;
    public uint Breed;
    public uint Gender;
    public string Label;
    public uint Order;
  }
}
