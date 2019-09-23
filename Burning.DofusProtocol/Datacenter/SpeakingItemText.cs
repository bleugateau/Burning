using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpeakingItemsText", true)]
  public class SpeakingItemText : IDataObject
  {
    public const string MODULE = "SpeakingItemsText";
    public int TextId;
    public double TextProba;
    public uint TextStringId;
    public int TextLevel;
    public int TextSound;
    public string TextRestriction;
  }
}
